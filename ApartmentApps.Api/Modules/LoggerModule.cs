using ApartmentApps.Data.Repository;

namespace ApartmentApps.Api.Modules
{
    public class LoggerModule : Module<LoggerSettings>, ILogger
    {
        private readonly IRepository<Log> _log;

        public LoggerModule(IRepository<Log> log, IRepository<LoggerSettings> configRepo, IUserContext userContext) : base(configRepo, userContext)
        {
            _log = log;
        }

        public void Error(string str, params object[] args)
        {
            _log.Add(new Log()
            {
                Message = args != null && args.Length > 0 ? string.Format(str, args) : str,
                Severity = LogSeverity.Error
            });
            _log.Save();
        }
        public void Warning(string str, params object[] args)
        {
            _log.Add(new Log()
            {
                Message = args != null && args.Length > 0 ? string.Format(str, args) : str,
                Severity = LogSeverity.Warning
            });
            _log.Save();
        }
        public void Info(string str, params object[] args)
        {
            _log.Add(new Log()
            {
                Message = args != null && args.Length > 0 ? string.Format(str, args) : str,
                Severity = LogSeverity.Info
            });
            _log.Save();
        }
    }
}