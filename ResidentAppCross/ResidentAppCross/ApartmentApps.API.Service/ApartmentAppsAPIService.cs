﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Net.Http;
using ApartmentApps.Client;
using Microsoft.Rest;

namespace ApartmentApps.Client
{
    public partial class ApartmentAppsAPIService : ServiceClient<ApartmentAppsAPIService>, IApartmentAppsAPIService
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }
        
        private ServiceClientCredentials _credentials;
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }
        
        private IAccount _account;
        
        public virtual IAccount Account
        {
            get { return this._account; }
        }
        
        private IAlerts _alerts;
        
        public virtual IAlerts Alerts
        {
            get { return this._alerts; }
        }
        
        private ICheckins _checkins;
        
        public virtual ICheckins Checkins
        {
            get { return this._checkins; }
        }
        
        private IConfigure _configure;
        
        public virtual IConfigure Configure
        {
            get { return this._configure; }
        }
        
        private ICourtesy _courtesy;
        
        public virtual ICourtesy Courtesy
        {
            get { return this._courtesy; }
        }
        
        private IInspections _inspections;
        
        public virtual IInspections Inspections
        {
            get { return this._inspections; }
        }
        
        private ILookups _lookups;
        
        public virtual ILookups Lookups
        {
            get { return this._lookups; }
        }
        
        private IMaitenance _maitenance;
        
        public virtual IMaitenance Maitenance
        {
            get { return this._maitenance; }
        }
        
        private IMessaging _messaging;
        
        public virtual IMessaging Messaging
        {
            get { return this._messaging; }
        }
        
        private INotifiations _notifiations;
        
        public virtual INotifiations Notifiations
        {
            get { return this._notifiations; }
        }
        
        private IPayments _payments;
        
        public virtual IPayments Payments
        {
            get { return this._payments; }
        }
        
        private IProspect _prospect;
        
        public virtual IProspect Prospect
        {
            get { return this._prospect; }
        }
        
        private IRegister _register;
        
        public virtual IRegister Register
        {
            get { return this._register; }
        }
        
        private IVersion _version;
        
        public virtual IVersion Version
        {
            get { return this._version; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ApartmentAppsAPIService class.
        /// </summary>
        public ApartmentAppsAPIService()
            : base()
        {
            this._account = new Account(this);
            this._alerts = new Alerts(this);
            this._checkins = new Checkins(this);
            this._configure = new Configure(this);
            this._courtesy = new Courtesy(this);
            this._inspections = new Inspections(this);
            this._lookups = new Lookups(this);
            this._maitenance = new Maitenance(this);
            this._messaging = new Messaging(this);
            this._notifiations = new Notifiations(this);
            this._payments = new Payments(this);
            this._prospect = new Prospect(this);
            this._register = new Register(this);
            this._version = new Version(this);
            this._baseUri = new Uri("http://localhost:54685");
        }
        
        /// <summary>
        /// Initializes a new instance of the ApartmentAppsAPIService class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ApartmentAppsAPIService(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._account = new Account(this);
            this._alerts = new Alerts(this);
            this._checkins = new Checkins(this);
            this._configure = new Configure(this);
            this._courtesy = new Courtesy(this);
            this._inspections = new Inspections(this);
            this._lookups = new Lookups(this);
            this._maitenance = new Maitenance(this);
            this._messaging = new Messaging(this);
            this._notifiations = new Notifiations(this);
            this._payments = new Payments(this);
            this._prospect = new Prospect(this);
            this._register = new Register(this);
            this._version = new Version(this);
            this._baseUri = new Uri("http://localhost:54685");
        }
        
        /// <summary>
        /// Initializes a new instance of the ApartmentAppsAPIService class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ApartmentAppsAPIService(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._account = new Account(this);
            this._alerts = new Alerts(this);
            this._checkins = new Checkins(this);
            this._configure = new Configure(this);
            this._courtesy = new Courtesy(this);
            this._inspections = new Inspections(this);
            this._lookups = new Lookups(this);
            this._maitenance = new Maitenance(this);
            this._messaging = new Messaging(this);
            this._notifiations = new Notifiations(this);
            this._payments = new Payments(this);
            this._prospect = new Prospect(this);
            this._register = new Register(this);
            this._version = new Version(this);
            this._baseUri = new Uri("http://localhost:54685");
        }
        
        /// <summary>
        /// Initializes a new instance of the ApartmentAppsAPIService class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ApartmentAppsAPIService(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }
        
        /// <summary>
        /// Initializes a new instance of the ApartmentAppsAPIService class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ApartmentAppsAPIService(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the ApartmentAppsAPIService class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ApartmentAppsAPIService(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
    }
}
