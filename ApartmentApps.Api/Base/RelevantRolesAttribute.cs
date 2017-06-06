using System;

namespace ApartmentApps.Api.Modules
{
    public class RelevantRolesAttribute : Attribute
    {
        public string[] RelevantRoles { get; set; }

        public RelevantRolesAttribute(params string[] relevantRoles)
        {
            RelevantRoles = relevantRoles;
        }
    }
}