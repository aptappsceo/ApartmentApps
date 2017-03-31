using System;
using System.Configuration;
using System.Collections;
using System.Threading;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Util;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text;
using System.Security.Principal;
using System.Xml;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Globalization;
using System.Web.Management;
using System.Web.Hosting;
using System.Web.Configuration;
using System.Web.SessionState;

namespace Azure.Utilities
{

    public class SqlSessionStateStore : SessionStateStoreProviderBase
    {

        internal enum SupportFlags : uint
        {
            None = 0x00000000,
            GetLockAge = 0x00000001,
            Uninitialized = 0xFFFFFFFF
        }

        static int s_commandTimeout;
        static bool s_oneTimeInited;
        static bool s_usePartition = false;
        static EventHandler s_onAppDomainUnload;


        // We keep these info because we don't want to hold on to the config object.
        static string s_configPartitionResolverType = null;
        static string s_configSqlConnectionFileName;
        static int s_configSqlConnectionLineNumber;
        static bool s_configAllowCustomSqlDatabase;
        static string s_sqlConnectionString;
        static SqlPartitionInfo s_singlePartitionInfo;

        // Per request info        
        HttpContext _rqContext;
        int _rqOrigStreamLen;
        SqlPartitionInfo _partitionInfo;

        const int ITEM_SHORT_LENGTH = 7000;
        const int SQL_ERROR_PRIMARY_KEY_VIOLATION = 2627;
        const int SQL_LOGIN_FAILED = 18456;
        const int SQL_LOGIN_FAILED_2 = 18452;
        const int SQL_LOGIN_FAILED_3 = 18450;
        const int APP_SUFFIX_LENGTH = 8;

        static int ID_LENGTH = SessionIDManager.SessionIDMaxLength + APP_SUFFIX_LENGTH;
        internal const int SQL_COMMAND_TIMEOUT_DEFAULT = 30;        // in sec

        public SqlSessionStateStore()
        {
        }


        public override void Initialize(string name, NameValueCollection config)
        {
            if (String.IsNullOrEmpty(name))
                name = "SQL Server Session State Provider";

            base.Initialize(name, config);

            if (!s_oneTimeInited)
            {
                try
                {
                    if (!s_oneTimeInited)
                    {
                        OneTimeInit();
                    }
                }
                finally
                {
                }
            }

            _partitionInfo = s_singlePartitionInfo;
        }

        void OneTimeInit()
        {
            SessionStateSection config = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");

            s_configSqlConnectionFileName = config.ElementInformation.Properties["sqlConnectionString"].Source;
            s_configSqlConnectionLineNumber = config.ElementInformation.Properties["sqlConnectionString"].LineNumber;
            s_configAllowCustomSqlDatabase = config.AllowCustomSqlDatabase;

            s_sqlConnectionString = config.SqlConnectionString;
            if (String.IsNullOrEmpty(s_sqlConnectionString)) throw new Exception("No connection string specified");
            s_singlePartitionInfo = CreatePartitionInfo(s_sqlConnectionString);

            s_commandTimeout = (int)config.SqlCommandTimeout.TotalSeconds;

            // We only need to do this in one instance
            s_onAppDomainUnload = new EventHandler(OnAppDomainUnload);
            Thread.GetDomain().DomainUnload += s_onAppDomainUnload;

            // Last thing to set.
            s_oneTimeInited = true;
        }

        void OnAppDomainUnload(Object unusedObject, EventArgs unusedEventArgs)
        {
            //Debug.Trace("SqlSessionStateStore", "OnAppDomainUnload called");

            Thread.GetDomain().DomainUnload -= s_onAppDomainUnload;
        }

        internal SqlPartitionInfo CreatePartitionInfo(string sqlConnectionString)
        {
            /*
             * Parse the connection string for errors. We want to ensure
             * that the user's connection string doesn't contain an
             * Initial Catalog entry, so we must first create a dummy connection.
             */
            SqlConnection dummyConnection;
            string attachDBFilename = null;

            try
            {
                dummyConnection = new SqlConnection(sqlConnectionString);
            }
            catch (Exception e)
            {
                throw new Exception(SR.GetString(SR.Error_parsing_session_sqlConnectionString, e.Message), e);
            }

            // Search for both Database and AttachDbFileName.  Don't append our
            // database name if either of them exists.
            string database = dummyConnection.Database;
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(sqlConnectionString);

            if (String.IsNullOrEmpty(database))
            {
                database = scsb.AttachDBFilename;
                attachDBFilename = database;
            }

            if (!String.IsNullOrEmpty(database))
            {
                if (!s_configAllowCustomSqlDatabase)
                {
                    throw new Exception(SR.GetString(SR.No_database_allowed_in_sqlConnectionString));
                }
            }
            else
            {
                scsb.Add("Initial Catalog", "ASPState");
            }

            return new SqlPartitionInfo(new ResourcePool(new TimeSpan(0, 0, 5), int.MaxValue),
                                            scsb.IntegratedSecurity,
                                            scsb.ConnectionString);

        }

        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            return false;
        }

        public override void Dispose()
        {
        }

        public override void InitializeRequest(HttpContext context)
        {
            _rqContext = context;
            _rqOrigStreamLen = 0;
        }

        public override void EndRequest(HttpContext context)
        {
            _rqContext = null;
        }

        public bool KnowForSureNotUsingIntegratedSecurity
        {
            get
            {
                if (_partitionInfo == null)
                {
                    // If we're using partitioning, we need the session id to figure out the connection
                    // string.  Without it, we can't know for sure.
                    return false;
                }
                else
                {
                    ////Debug.Assert(_partitionInfo != null);
                    return !_partitionInfo.UseIntegratedSecurity;
                }
            }
        }

        //
        // Regarding resource pool, we will turn it on if in <identity>:
        //  - User is not using integrated security
        //  - impersonation = "false"
        //  - impersonation = "true" and userName/password is NON-null
        //  - impersonation = "true" and IIS is using Anonymous
        //
        // Otherwise, the impersonated account will be dynamic and we have to turn
        // resource pooling off.
        //
        // Note:
        // In case 2. above, the user can specify different usernames in different 
        // web.config in different subdirs in the app.  In this case, we will just 
        // cache the connections in the resource pool based on the identity of the 
        // connection.  So in this specific scenario it is possible to have the 
        // resource pool filled with mixed identities.
        // 
        bool CanUsePooling()
        {
            bool ret = false;

            if (KnowForSureNotUsingIntegratedSecurity)
            {
                ret = true;
            }
            else if (_rqContext == null)
            {
                // One way this can happen is we hit an error on page compilation,
                // and SessionStateModule.OnEndRequest is called
                ret = false;
            }

            return ret;
        }

        SqlStateConnection GetConnection(string id, ref bool usePooling)
        {
            SqlStateConnection conn = null;

            if (_partitionInfo == null)
            {
                _partitionInfo = s_singlePartitionInfo;
            }

            usePooling = CanUsePooling();
            if (usePooling)
            {
                conn = (SqlStateConnection)_partitionInfo.RetrieveResource();
                if (conn != null && (conn.Connection.State & ConnectionState.Open) == 0)
                {
                    conn.Dispose();
                    conn = null;
                }
            }

            if (conn == null)
            {
                conn = new SqlStateConnection(_partitionInfo);
            }

            return conn;
        }

        void DisposeOrReuseConnection(ref SqlStateConnection conn, bool usePooling)
        {
            try
            {
                if (conn == null)
                {
                    return;
                }

                if (usePooling)
                {
                    _partitionInfo.StoreResource(conn);
                    conn = null;
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        internal static void ThrowSqlConnectionException(SqlConnection conn, Exception e)
        {
            if (s_usePartition)
            {
                throw new HttpException(
                    SR.GetString(SR.Cant_connect_sql_session_database_partition_resolver,
                                s_configPartitionResolverType, conn.DataSource, conn.Database));
            }
            else
            {
                throw new HttpException(
                    SR.GetString(SR.Cant_connect_sql_session_database),
                    e);
            }
        }

        SessionStateStoreData DoGet(HttpContext context, String id, bool getExclusive,
                                        out bool locked,
                                        out TimeSpan lockAge,
                                        out object lockId,
                                        out SessionStateActions actionFlags)
        {
            SqlDataReader reader;
            byte[] buf;
            MemoryStream stream = null;
            SessionStateStoreData item;
            bool useGetLockAge = false;
            SqlStateConnection conn = null;
            SqlCommand cmd = null;
            bool usePooling = true;

            // Set default return values
            locked = false;
            lockId = null;
            lockAge = TimeSpan.Zero;
            actionFlags = 0;

            buf = null;
            reader = null;

            conn = GetConnection(id, ref usePooling);

            //
            // In general, if we're talking to a SQL 2000 or above, we use LockAge; otherwise we use LockDate.
            // Below are the details:
            //
            // Version 1
            // ---------
            // In v1, the lockDate is generated and stored in SQL using local time, and we calculate the "lockage"
            // (i.e. how long the item is locked) by having the web server read lockDate from SQL and substract it 
            // from DateTime.Now.  But this approach introduced two problems:
            //  1. SQL server and web servers need to be in the same time zone.
            //  2. Daylight savings problem.
            //
            // Version 1.1
            // -----------
            // In v1.1, if using SQL 2000 we fixed the problem by calculating the "lockage" directly in SQL 
            // so that the SQL server and the web server don't have to be in the same time zone.  We also
            // use UTC date to store time in SQL so that the Daylight savings problem is solved.
            //
            // In summary, if using SQL 2000 we made the following changes to the SQL tables:
            //      i. The column Expires is using now UTC time
            //     ii. Add new SP TempGetStateItem2 and TempGetStateItemExclusive2 to return a lockage
            //         instead of a lockDate.
            //    iii. To support v1 web server, we still need to have TempGetStateItem and 
            //         TempGetStateItemExclusive.  However, we modify it a bit so that they use
            //         UTC time to update Expires column.
            //
            // If using SQL 7, we decided not to fix the problem, and the SQL scripts for SQL 7 remain pretty much 
            // the same. That means v1.1 web server will continue to call TempGetStateItem and 
            // TempGetStateItemExclusive and use v1 way to calculate the "lockage".
            //
            // Version 2.0
            // -----------
            // In v2.0 we added some new SP TempGetStateItem3 and TempGetStateItemExclusive3
            // because we added a new return value 'actionFlags'.  However, the principle remains the same
            // that we support lockAge only if talking to SQL 2000.
            //
            // (When one day MS stops supporting SQL 7 we can remove all the SQL7-specific scripts and
            //  stop all these craziness.)
            // 
            if ((_partitionInfo.SupportFlags & SupportFlags.GetLockAge) != 0)
            {
                useGetLockAge = true;
            }

            try
            {
                if (getExclusive)
                {
                    cmd = conn.TempGetExclusive;
                }
                else
                {
                    cmd = conn.TempGet;
                }

                cmd.Parameters[0].Value = id + _partitionInfo.AppSuffix; // @id
                cmd.Parameters[1].Value = Convert.DBNull;   // @itemShort
                cmd.Parameters[2].Value = Convert.DBNull;   // @locked
                cmd.Parameters[3].Value = Convert.DBNull;   // @lockDate or @lockAge
                cmd.Parameters[4].Value = Convert.DBNull;   // @lockCookie
                cmd.Parameters[5].Value = Convert.DBNull;   // @actionFlags

                try
                {
                    reader = cmd.ExecuteReader();

                    /* If the cmd returned data, we must read it all before getting out params */
                    if (reader != null)
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                buf = (byte[])reader[0];
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    ThrowSqlConnectionException(cmd.Connection, e);
                }

                /* Check if value was returned */
                if (Convert.IsDBNull(cmd.Parameters[2].Value))
                {
                    //Debug.Trace("SqlSessionStateStore", "Sql Get returned null");
                    return null;
                }

                /* Check if item is locked */
                locked = (bool)cmd.Parameters[2].Value;
                lockId = (int)cmd.Parameters[4].Value;

                if (locked)
                {


                    if (useGetLockAge)
                    {
                        lockAge = new TimeSpan(0, 0, (int)cmd.Parameters[3].Value);
                    }
                    else
                    {
                        DateTime lockDate;
                        lockDate = (DateTime)cmd.Parameters[3].Value;
                        lockAge = DateTime.Now - lockDate;
                    }


                    if (lockAge > new TimeSpan(0, 0, 30758400 /* one year */))
                    {
                        lockAge = TimeSpan.Zero;
                    }
                    return null;
                }

                actionFlags = (SessionStateActions)cmd.Parameters[5].Value;

                if (buf == null)
                {
                    /* Get short item */
                    buf = (byte[])cmd.Parameters[1].Value;
                }

                // Done with the connection.
                DisposeOrReuseConnection(ref conn, usePooling);

                try
                {
                    stream = new MemoryStream(buf);
                    item = Deserialize(context, stream);
                    _rqOrigStreamLen = (int)stream.Position;
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }

                return item;
            }
            finally
            {
                DisposeOrReuseConnection(ref conn, usePooling);
            }
        }

        public override SessionStateStoreData GetItem(HttpContext context,
                                                        String id,
                                                        out bool locked,
                                                        out TimeSpan lockAge,
                                                        out object lockId,
                                                        out SessionStateActions actionFlags)
        {
            return DoGet(context, id, false, out locked, out lockAge, out lockId, out actionFlags);
        }

        public override SessionStateStoreData GetItemExclusive(HttpContext context,
                                                String id,
                                                out bool locked,
                                                out TimeSpan lockAge,
                                                out object lockId,
                                                out SessionStateActions actionFlags)
        {
            return DoGet(context, id, true, out locked, out lockAge, out lockId, out actionFlags);
        }

        // This will deserialize and return an item.
        // This version uses the default classes for SessionStateItemCollection, HttpStaticObjectsCollection
        // and SessionStateStoreData
        private static SessionStateStoreData Deserialize(HttpContext context, Stream stream)
        {

            int timeout;
            SessionStateItemCollection sessionItems;
            bool hasItems;
            bool hasStaticObjects;
            HttpStaticObjectsCollection staticObjects;
            Byte eof;


            try
            {
                BinaryReader reader = new BinaryReader(stream);
                timeout = reader.ReadInt32();
                hasItems = reader.ReadBoolean();
                hasStaticObjects = reader.ReadBoolean();

                if (hasItems)
                {
                    sessionItems = SessionStateItemCollection.Deserialize(reader);
                }
                else
                {
                    sessionItems = new SessionStateItemCollection();
                }

                if (hasStaticObjects)
                {
                    staticObjects = HttpStaticObjectsCollection.Deserialize(reader);
                }
                else
                {
                    staticObjects = SessionStateUtility.GetSessionStaticObjects(context);
                }

                eof = reader.ReadByte();
                if (eof != 0xff)
                {
                    throw new HttpException(SR.GetString(SR.Invalid_session_state));
                }
            }
            catch (EndOfStreamException)
            {
                throw new HttpException(SR.GetString(SR.Invalid_session_state));
            }

            return new SessionStateStoreData(sessionItems, staticObjects, timeout);
        }

        private static SessionStateStoreData CreateLegitStoreData(HttpContext context,
                                                    ISessionStateItemCollection sessionItems,
                                                    HttpStaticObjectsCollection staticObjects,
                                                    int timeout)
        {
            if (sessionItems == null)
            {
                sessionItems = new SessionStateItemCollection();
            }

            if (staticObjects == null && context != null)
            {
                staticObjects = SessionStateUtility.GetSessionStaticObjects(context);
            }

            return new SessionStateStoreData(sessionItems, staticObjects, timeout);
        }

        static private void SerializeStoreData(SessionStateStoreData item, int initialStreamSize, out byte[] buf, out int length)
        {
            MemoryStream s = null;

            try
            {
                s = new MemoryStream(initialStreamSize);

                Serialize(item, s);
                buf = s.GetBuffer();
                length = (int)s.Length;
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }
        }

        // This method will take an item and serialize it
        private static void Serialize(SessionStateStoreData item, Stream stream)
        {
            bool hasItems = true;
            bool hasStaticObjects = true;

            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(item.Timeout);

            if (item.Items == null || item.Items.Count == 0)
            {
                hasItems = false;
            }
            writer.Write(hasItems);

            if (item.StaticObjects == null || item.StaticObjects.NeverAccessed)
            {
                hasStaticObjects = false;
            }
            writer.Write(hasStaticObjects);

            if (hasItems)
            {
                ((SessionStateItemCollection)item.Items).Serialize(writer);
            }

            if (hasStaticObjects)
            {
                item.StaticObjects.Serialize(writer);
            }

            // Prevent truncation of the stream
            writer.Write(unchecked((byte)0xff));
        }



        public override void ReleaseItemExclusive(HttpContext context,
                                String id,
                                object lockId)
        {

            bool usePooling = true;
            SqlStateConnection conn = null;
            int lockCookie = (int)lockId;

            try
            {

                conn = GetConnection(id, ref usePooling);
                try
                {
                    SqlCommand cmd = conn.TempReleaseExclusive;

                    cmd.Parameters[0].Value = id + _partitionInfo.AppSuffix;
                    cmd.Parameters[1].Value = lockCookie;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ThrowSqlConnectionException(conn.Connection, e);
                }

            }
            finally
            {
                DisposeOrReuseConnection(ref conn, usePooling);
            }
        }

        public override void SetAndReleaseItemExclusive(HttpContext context,
                                    String id,
                                    SessionStateStoreData item,
                                    object lockId,
                                    bool newItem)
        {
            byte[] buf;
            int length;
            SqlCommand cmd;
            bool usePooling = true;
            SqlStateConnection conn = null;
            int lockCookie;


            try
            {

                try
                {
                    SerializeStoreData(item, ITEM_SHORT_LENGTH, out buf, out length);
                }
                catch
                {
                    if (!newItem)
                    {
                        ((SessionStateStoreProviderBase)this).ReleaseItemExclusive(context, id, lockId);
                    }
                    throw;
                }

                // Save it to the store

                if (lockId == null)
                {
                    lockCookie = 0;
                }
                else
                {
                    lockCookie = (int)lockId;
                }

                conn = GetConnection(id, ref usePooling);

                if (!newItem)
                {
                    if (length <= ITEM_SHORT_LENGTH)
                    {
                        if (_rqOrigStreamLen <= ITEM_SHORT_LENGTH)
                        {
                            cmd = conn.TempUpdateShort;
                        }
                        else
                        {
                            cmd = conn.TempUpdateShortNullLong;
                        }
                    }
                    else
                    {
                        if (_rqOrigStreamLen <= ITEM_SHORT_LENGTH)
                        {
                            cmd = conn.TempUpdateLongNullShort;
                        }
                        else
                        {
                            cmd = conn.TempUpdateLong;
                        }
                    }

                }
                else
                {
                    if (length <= ITEM_SHORT_LENGTH)
                    {
                        cmd = conn.TempInsertShort;
                    }
                    else
                    {
                        cmd = conn.TempInsertLong;
                    }
                }

                cmd.Parameters[0].Value = id + _partitionInfo.AppSuffix;
                cmd.Parameters[1].Size = length;
                cmd.Parameters[1].Value = buf;
                cmd.Parameters[2].Value = item.Timeout;
                if (!newItem)
                {
                    cmd.Parameters[3].Value = lockCookie;
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    HandleInsertException(conn.Connection, e, newItem, id);
                }
            }
            finally
            {
                DisposeOrReuseConnection(ref conn, usePooling);
            }
        }

        public override void RemoveItem(HttpContext context,
                                        String id,
                                        object lockId,
                                        SessionStateStoreData item)
        {

            bool usePooling = true;
            SqlStateConnection conn = null;
            int lockCookie = (int)lockId;

            try
            {

                conn = GetConnection(id, ref usePooling);
                try
                {
                    SqlCommand cmd = conn.TempRemove;
                    cmd.Parameters[0].Value = id + _partitionInfo.AppSuffix;
                    cmd.Parameters[1].Value = lockCookie;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ThrowSqlConnectionException(conn.Connection, e);
                }

            }
            finally
            {
                DisposeOrReuseConnection(ref conn, usePooling);
            }
        }

        public override void ResetItemTimeout(HttpContext context, String id)
        {
            bool usePooling = true;
            SqlStateConnection conn = null;

            try
            {

                conn = GetConnection(id, ref usePooling);
                try
                {
                    SqlCommand cmd = conn.TempResetTimeout;
                    cmd.Parameters[0].Value = id + _partitionInfo.AppSuffix;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ThrowSqlConnectionException(conn.Connection, e);
                }
            }
            finally
            {
                DisposeOrReuseConnection(ref conn, usePooling);
            }
        }

        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            return CreateLegitStoreData(context, null, null, timeout);
        }

        public override void CreateUninitializedItem(HttpContext context, String id, int timeout)
        {

            bool usePooling = true;
            SqlStateConnection conn = null;
            byte[] buf;
            int length;

            try
            {
                // Store an empty data
                SerializeStoreData(CreateNewStoreData(context, timeout),
                                ITEM_SHORT_LENGTH, out buf, out length);

                conn = GetConnection(id, ref usePooling);

                try
                {
                    SqlCommand cmd = conn.TempInsertUninitializedItem;
                    cmd.Parameters[0].Value = id + _partitionInfo.AppSuffix;
                    cmd.Parameters[1].Size = length;
                    cmd.Parameters[1].Value = buf;
                    cmd.Parameters[2].Value = timeout;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    HandleInsertException(conn.Connection, e, true, id);
                }
            }
            finally
            {
                DisposeOrReuseConnection(ref conn, usePooling);
            }
        }

        void HandleInsertException(SqlConnection conn, Exception e, bool newItem, string id)
        {
            SqlException sqlExpt = e as SqlException;
            if (sqlExpt != null &&
                sqlExpt.Number == SQL_ERROR_PRIMARY_KEY_VIOLATION &&
                newItem)
            {

                // It's possible that two threads (from the same session) are creating the session
                // state, both failed to get it first, and now both tried to insert it.
                // One thread may lose with a Primary Key Violation error. If so, that thread will
                // just lose and exit gracefully.
            }
            else
            {
                ThrowSqlConnectionException(conn, e);
            }
        }

        internal class PartitionInfo : IDisposable
        {
            ResourcePool _rpool;

            internal PartitionInfo(ResourcePool rpool)
            {
                _rpool = rpool;
            }

            internal object RetrieveResource()
            {
                return _rpool.RetrieveResource();
            }

            internal void StoreResource(IDisposable o)
            {
                _rpool.StoreResource(o);
            }

            protected virtual string TracingPartitionString
            {
                get
                {
                    return String.Empty;
                }
            }

            string GetTracingPartitionString()
            {
                return TracingPartitionString;
            }

            public void Dispose()
            {
                if (_rpool == null)
                {
                    return;
                }

                lock (this)
                {
                    if (_rpool != null)
                    {
                        _rpool.Dispose();
                        _rpool = null;
                    }
                }
            }
        };

        internal class SqlPartitionInfo : PartitionInfo
        {
            bool _useIntegratedSecurity;
            string _sqlConnectionString;
            string _tracingPartitionString;
            SupportFlags _support = SupportFlags.Uninitialized;
            string _appSuffix;
            object _lock = new object();
            bool _sqlInfoInited;

            const string APP_SUFFIX_FORMAT = "x8";
            const int APPID_MAX = 280;
            const int SQL_2000_MAJ_VER = 8;

            internal SqlPartitionInfo(ResourcePool rpool, bool useIntegratedSecurity, string sqlConnectionString)
                : base(rpool)
            {
                _useIntegratedSecurity = useIntegratedSecurity;
                _sqlConnectionString = sqlConnectionString;
            }

            internal bool UseIntegratedSecurity
            {
                get { return _useIntegratedSecurity; }
            }

            internal string SqlConnectionString
            {
                get { return _sqlConnectionString; }
            }

            internal SupportFlags SupportFlags
            {
                get { return _support; }
                set { _support = value; }
            }

            protected override string TracingPartitionString
            {
                get
                {
                    if (_tracingPartitionString == null)
                    {
                        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_sqlConnectionString);
                        builder.Password = String.Empty;
                        builder.UserID = String.Empty;
                        _tracingPartitionString = builder.ConnectionString;
                    }
                    return _tracingPartitionString;
                }
            }

            internal string AppSuffix
            {
                get { return _appSuffix; }
            }


            void GetServerSupportOptions(SqlConnection sqlConnection)
            {

                SupportFlags flags = SupportFlags.None;
                // For details, see the extensive doc in DoGet method.
                flags |= SupportFlags.GetLockAge;
                SupportFlags = flags;

            }


            internal void InitSqlInfo(SqlConnection sqlConnection)
            {
                if (_sqlInfoInited)
                {
                    return;
                }

                lock (_lock)
                {
                    if (_sqlInfoInited)
                    {
                        return;
                    }

                    GetServerSupportOptions(sqlConnection);

                    // Get AppSuffix info

                    SqlParameter p;

                    SqlCommand cmdTempGetAppId = new SqlCommand("TempGetAppID", sqlConnection);
                    cmdTempGetAppId.CommandType = CommandType.StoredProcedure;
                    cmdTempGetAppId.CommandTimeout = s_commandTimeout;

                    // AppDomainAppIdInternal will contain the whole metabase path of the request's app
                    // e.g. /lm/w3svc/1/root/fxtest    
                    p = cmdTempGetAppId.Parameters.Add(new SqlParameter("@appName", SqlDbType.VarChar, APPID_MAX));
                    p.Value = HttpRuntime.AppDomainAppId;

                    p = cmdTempGetAppId.Parameters.Add(new SqlParameter("@appId", SqlDbType.Int));
                    p.Direction = ParameterDirection.Output;
                    p.Value = Convert.DBNull;

                    cmdTempGetAppId.ExecuteNonQuery();
                    //Debug.Assert(!Convert.IsDBNull(p), "!Convert.IsDBNull(p)");
                    int appId = (int)p.Value;
                    _appSuffix = (appId).ToString(APP_SUFFIX_FORMAT, CultureInfo.InvariantCulture);

                    _sqlInfoInited = true;
                }
            }
        };

        /*
            Here are all the sprocs created for session state and how they're used:
            
            CreateTempTables
            - Called during setup
            
            DeleteExpiredSessions
            - Called by SQL agent to remove expired sessions
            
            GetHashCode
            - Called by sproc TempGetAppID
            
            GetMajorVersion
            - Called during setup
            
            TempGetAppID
            - Called when an asp.net application starts up
            
            TempGetStateItem
            - Used for ReadOnly session state
            - Called by v1 asp.net
            - Called by v1.1 asp.net against SQL 7
            
            TempGetStateItem2
            - Used for ReadOnly session state
            - Called by v1.1 asp.net against SQL 2000
            
            TempGetStateItem3
            - Used for ReadOnly session state
            - Called by v2 asp.net
            
            TempGetStateItemExclusive
            - Called by v1 asp.net
            - Called by v1.1 asp.net against SQL 7
            
            TempGetStateItemExclusive2
            - Called by v1.1 asp.net against SQL 2000
            
            TempGetStateItemExclusive3
            - Called by v2 asp.net
            
            TempGetVersion
            - Called by v2 asp.net when an application starts up
            
            TempInsertStateItemLong
            - Used when creating a new session state with size > 7000 bytes
            
            TempInsertStateItemShort
            - Used when creating a new session state with size <= 7000 bytes
            
            TempInsertUninitializedItem
            - Used when creating a new uninitilized session state (cookieless="true" and regenerateExpiredSessionId="true" in config)
            
            TempReleaseStateItemExclusive
            - Used when a request that has acquired the session state (exclusively) hit an error during the page execution
            
            TempRemoveStateItem
            - Used when a session is abandoned
            
            TempResetTimeout
            - Used when a request (with an active session state) is handled by an HttpHandler which doesn't support IRequiresSessionState interface.
            
            TempUpdateStateItemLong
            - Used when updating a session state with size > 7000 bytes
            
            TempUpdateStateItemLongNullShort
            - Used when updating a session state where original size <= 7000 bytes but new size > 7000 bytes
            
            TempUpdateStateItemShort
            - Used when updating a session state with size <= 7000 bytes
            
            TempUpdateStateItemShortNullLong
            - Used when updating a session state where original size > 7000 bytes but new size <= 7000 bytes

        */
        class SqlStateConnection : IDisposable
        {
            SqlConnection _sqlConnection;
            SqlCommand _cmdTempGet;
            SqlCommand _cmdTempGetExclusive;
            SqlCommand _cmdTempReleaseExclusive;
            SqlCommand _cmdTempInsertShort;
            SqlCommand _cmdTempInsertLong;
            SqlCommand _cmdTempUpdateShort;
            SqlCommand _cmdTempUpdateShortNullLong;
            SqlCommand _cmdTempUpdateLong;
            SqlCommand _cmdTempUpdateLongNullShort;
            SqlCommand _cmdTempRemove;
            SqlCommand _cmdTempResetTimeout;
            SqlCommand _cmdTempInsertUninitializedItem;

            SqlPartitionInfo _partitionInfo;

            internal SqlStateConnection(SqlPartitionInfo partitionInfo)
            {
                _partitionInfo = partitionInfo;
                _sqlConnection = new SqlConnection(_partitionInfo.SqlConnectionString);

                try
                {
                    _sqlConnection.Open();
                }
                catch (Exception e)
                {
                    SqlConnection connection = _sqlConnection;
                    SqlException sqlExpt = e as SqlException;

                    _sqlConnection = null;

                    if (sqlExpt != null &&
                        (sqlExpt.Number == SQL_LOGIN_FAILED ||
                         sqlExpt.Number == SQL_LOGIN_FAILED_2 ||
                         sqlExpt.Number == SQL_LOGIN_FAILED_3))
                    {
                        string user;

                        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(partitionInfo.SqlConnectionString);
                        if (scsb.IntegratedSecurity)
                        {
                            user = WindowsIdentity.GetCurrent().Name;
                        }
                        else
                        {
                            user = scsb.UserID;
                        }

                        HttpException outerException = new HttpException(
                                    SR.GetString(SR.Login_failed_sql_session_database, user), e);

                        e = outerException;
                    }

                    SqlSessionStateStore.ThrowSqlConnectionException(connection, e);
                }

            }

            internal SqlCommand TempGet
            {
                get
                {
                    if (_cmdTempGet == null)
                    {
                        SqlParameter p;

                        _cmdTempGet = new SqlCommand("TempGetStateItem3", _sqlConnection);
                        _cmdTempGet.CommandType = CommandType.StoredProcedure;
                        _cmdTempGet.CommandTimeout = s_commandTimeout;

                        // Use a different set of parameters for the sprocs that support GetLockAge
                        if ((_partitionInfo.SupportFlags & SupportFlags.GetLockAge) != 0)
                        {
                            _cmdTempGet.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@locked", SqlDbType.Bit));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@lockAge", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@actionFlags", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            _cmdTempGet.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@locked", SqlDbType.Bit));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@lockDate", SqlDbType.DateTime));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGet.Parameters.Add(new SqlParameter("@actionFlags", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                        }
                    }

                    return _cmdTempGet;
                }
            }

            internal SqlCommand TempGetExclusive
            {
                get
                {
                    if (_cmdTempGetExclusive == null)
                    {
                        SqlParameter p;

                        _cmdTempGetExclusive = new SqlCommand("TempGetStateItemExclusive3", _sqlConnection);
                        _cmdTempGetExclusive.CommandType = CommandType.StoredProcedure;
                        _cmdTempGetExclusive.CommandTimeout = s_commandTimeout;

                        // Use a different set of parameters for the sprocs that support GetLockAge
                        if ((_partitionInfo.SupportFlags & SupportFlags.GetLockAge) != 0)
                        {
                            _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@locked", SqlDbType.Bit));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@lockAge", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@actionFlags", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@locked", SqlDbType.Bit));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@lockDate", SqlDbType.DateTime));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                            p = _cmdTempGetExclusive.Parameters.Add(new SqlParameter("@actionFlags", SqlDbType.Int));
                            p.Direction = ParameterDirection.Output;
                        }
                    }

                    return _cmdTempGetExclusive;
                }
            }

            internal SqlCommand TempReleaseExclusive
            {
                get
                {
                    if (_cmdTempReleaseExclusive == null)
                    {
                        /* ReleaseExlusive */
                        _cmdTempReleaseExclusive = new SqlCommand("TempReleaseStateItemExclusive", _sqlConnection);
                        _cmdTempReleaseExclusive.CommandType = CommandType.StoredProcedure;
                        _cmdTempReleaseExclusive.CommandTimeout = s_commandTimeout;
                        _cmdTempReleaseExclusive.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempReleaseExclusive.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                    }

                    return _cmdTempReleaseExclusive;
                }
            }

            internal SqlCommand TempInsertLong
            {
                get
                {
                    if (_cmdTempInsertLong == null)
                    {
                        _cmdTempInsertLong = new SqlCommand("TempInsertStateItemLong", _sqlConnection);
                        _cmdTempInsertLong.CommandType = CommandType.StoredProcedure;
                        _cmdTempInsertLong.CommandTimeout = s_commandTimeout;
                        _cmdTempInsertLong.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempInsertLong.Parameters.Add(new SqlParameter("@itemLong", SqlDbType.Image, 8000));
                        _cmdTempInsertLong.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                    }

                    return _cmdTempInsertLong;
                }
            }

            internal SqlCommand TempInsertShort
            {
                get
                {
                    /* Insert */
                    if (_cmdTempInsertShort == null)
                    {
                        _cmdTempInsertShort = new SqlCommand("TempInsertStateItemShort", _sqlConnection);
                        _cmdTempInsertShort.CommandType = CommandType.StoredProcedure;
                        _cmdTempInsertShort.CommandTimeout = s_commandTimeout;
                        _cmdTempInsertShort.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempInsertShort.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                        _cmdTempInsertShort.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                    }

                    return _cmdTempInsertShort;
                }
            }

            internal SqlCommand TempUpdateLong
            {
                get
                {
                    if (_cmdTempUpdateLong == null)
                    {
                        _cmdTempUpdateLong = new SqlCommand("TempUpdateStateItemLong", _sqlConnection);
                        _cmdTempUpdateLong.CommandType = CommandType.StoredProcedure;
                        _cmdTempUpdateLong.CommandTimeout = s_commandTimeout;
                        _cmdTempUpdateLong.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempUpdateLong.Parameters.Add(new SqlParameter("@itemLong", SqlDbType.Image, 8000));
                        _cmdTempUpdateLong.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                        _cmdTempUpdateLong.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                    }

                    return _cmdTempUpdateLong;
                }
            }

            internal SqlCommand TempUpdateShort
            {
                get
                {
                    /* Update */
                    if (_cmdTempUpdateShort == null)
                    {
                        _cmdTempUpdateShort = new SqlCommand("TempUpdateStateItemShort", _sqlConnection);
                        _cmdTempUpdateShort.CommandType = CommandType.StoredProcedure;
                        _cmdTempUpdateShort.CommandTimeout = s_commandTimeout;
                        _cmdTempUpdateShort.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempUpdateShort.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                        _cmdTempUpdateShort.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                        _cmdTempUpdateShort.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                    }

                    return _cmdTempUpdateShort;

                }
            }

            internal SqlCommand TempUpdateShortNullLong
            {
                get
                {
                    if (_cmdTempUpdateShortNullLong == null)
                    {
                        _cmdTempUpdateShortNullLong = new SqlCommand("TempUpdateStateItemShortNullLong", _sqlConnection);
                        _cmdTempUpdateShortNullLong.CommandType = CommandType.StoredProcedure;
                        _cmdTempUpdateShortNullLong.CommandTimeout = s_commandTimeout;
                        _cmdTempUpdateShortNullLong.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempUpdateShortNullLong.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                        _cmdTempUpdateShortNullLong.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                        _cmdTempUpdateShortNullLong.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                    }

                    return _cmdTempUpdateShortNullLong;
                }
            }

            internal SqlCommand TempUpdateLongNullShort
            {
                get
                {
                    if (_cmdTempUpdateLongNullShort == null)
                    {
                        _cmdTempUpdateLongNullShort = new SqlCommand("TempUpdateStateItemLongNullShort", _sqlConnection);
                        _cmdTempUpdateLongNullShort.CommandType = CommandType.StoredProcedure;
                        _cmdTempUpdateLongNullShort.CommandTimeout = s_commandTimeout;
                        _cmdTempUpdateLongNullShort.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempUpdateLongNullShort.Parameters.Add(new SqlParameter("@itemLong", SqlDbType.Image, 8000));
                        _cmdTempUpdateLongNullShort.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                        _cmdTempUpdateLongNullShort.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));
                    }

                    return _cmdTempUpdateLongNullShort;
                }
            }

            internal SqlCommand TempRemove
            {
                get
                {
                    if (_cmdTempRemove == null)
                    {
                        /* Remove */
                        _cmdTempRemove = new SqlCommand("TempRemoveStateItem", _sqlConnection);
                        _cmdTempRemove.CommandType = CommandType.StoredProcedure;
                        _cmdTempRemove.CommandTimeout = s_commandTimeout;
                        _cmdTempRemove.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempRemove.Parameters.Add(new SqlParameter("@lockCookie", SqlDbType.Int));

                    }

                    return _cmdTempRemove;
                }
            }

            internal SqlCommand TempInsertUninitializedItem
            {
                get
                {
                    if (_cmdTempInsertUninitializedItem == null)
                    {
                        _cmdTempInsertUninitializedItem = new SqlCommand("TempInsertUninitializedItem", _sqlConnection);
                        _cmdTempInsertUninitializedItem.CommandType = CommandType.StoredProcedure;
                        _cmdTempInsertUninitializedItem.CommandTimeout = s_commandTimeout;
                        _cmdTempInsertUninitializedItem.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                        _cmdTempInsertUninitializedItem.Parameters.Add(new SqlParameter("@itemShort", SqlDbType.VarBinary, ITEM_SHORT_LENGTH));
                        _cmdTempInsertUninitializedItem.Parameters.Add(new SqlParameter("@timeout", SqlDbType.Int));
                    }

                    return _cmdTempInsertUninitializedItem;
                }
            }

            internal SqlCommand TempResetTimeout
            {
                get
                {
                    if (_cmdTempResetTimeout == null)
                    {
                        /* ResetTimeout */
                        _cmdTempResetTimeout = new SqlCommand("TempResetTimeout", _sqlConnection);
                        _cmdTempResetTimeout.CommandType = CommandType.StoredProcedure;
                        _cmdTempResetTimeout.CommandTimeout = s_commandTimeout;
                        _cmdTempResetTimeout.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar, ID_LENGTH));
                    }

                    return _cmdTempResetTimeout;
                }
            }

            public void Dispose()
            {
                if (_sqlConnection != null)
                {
                    _sqlConnection.Close();
                    _sqlConnection = null;
                }
            }

            internal SqlConnection Connection
            {
                get { return _sqlConnection; }
            }
        }
    }

}
