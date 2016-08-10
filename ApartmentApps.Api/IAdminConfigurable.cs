namespace ApartmentApps.Api.Modules
{
    public interface IAdminConfigurable : IModule
    {
        string SettingsController { get; }
    }
}