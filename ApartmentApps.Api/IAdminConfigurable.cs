using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    public interface IAdminConfigurable : IModule
    {
        string SettingsController { get; }
    }

    public interface IUserConfigurable<T> where T : IUserConfig
    {
        T CreateDefault();
        T GetForUser(string id);
    }

    public interface IUserConfig
    {
        string Title { get; }
    }

    public abstract class UserConfig : IUserConfig
    {
        public abstract string Title { get; }

        [Key]
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }

    }

    public class RelevantRolesAttribute : Attribute
    {
        public string[] RelevantRoles { get; set; }

        public RelevantRolesAttribute(params string[] relevantRoles)
        {
            RelevantRoles = relevantRoles;
        }
    }

}