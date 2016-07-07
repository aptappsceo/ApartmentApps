namespace ApartmentApps.Api.Modules
{
    public interface ILogger
    {
        void Error(string str, params object[] args);
        void Warning(string str, params object[] args);
        void Info(string str, params object[] args);
    }
}