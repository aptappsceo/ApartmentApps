namespace ApartmentApps.Portal.Controllers
{
    public interface IServiceQueryVariableProvider
    {
        object GetVariable(string name);
    }
}