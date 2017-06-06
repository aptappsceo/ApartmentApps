using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public interface IAdminConfigurable : IModule
    {
        string SettingsController { get; }
    }
}