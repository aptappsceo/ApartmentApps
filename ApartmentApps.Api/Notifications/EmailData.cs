using System.Collections.Generic;
using ApartmentApps.Api.ViewModels;

namespace ApartmentApps.Api.NewFolder1
{
    public class EmailData
    {
        public Dictionary<string, string> Links { get; set; } = new Dictionary<string, string>();
        public UserBindingModel User { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string HeaderLogoImageUrl { get; set; }
    }
}