using System;

namespace ApartmentApps.Portal.Controllers
{
    public class UserQueryAttribute : Attribute
    {
        public UserQueryAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
}