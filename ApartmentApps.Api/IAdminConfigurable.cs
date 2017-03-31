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

    public interface IUserConfigurable<T>
    {

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