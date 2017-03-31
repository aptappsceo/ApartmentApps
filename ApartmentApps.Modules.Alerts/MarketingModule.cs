using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Api.Services;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Ninject;
using RazorEngine.Templating;

namespace ApartmentApps.Api
{
    public class MarketingModule : Module<MarketingModuleConfig>, IWebJob , IAdminConfigurable
    {
        public MarketingModule(IKernel kernel, IRepository<MarketingModuleConfig> configRepo, IUserContext userContext) : base(kernel, configRepo, userContext)
        {
            Razor = RazorEngineService.Create();
        }

        public IRazorEngineService Razor { get; set; }

        public void SendUserEngagementLetter(ApplicationUser user)
        {
            var mapper = Kernel.Get<IMapper<ApplicationUser, UserBindingModel>>();
            var queuer = Kernel.Get<EmailQueuer>();

            queuer.QueueEmail(new ActionEmailData()
            {
                Subject = $"Your account for {user.Property.Name} is ready!",
                Message = "Your account must be registered in order to submit maintenance requests of any kind for this property.  Click the button below to begin the process.",
                ToEmail = user.Email,
                User = mapper.ToViewModel(user),
                Links = new Dictionary<string, string>()
                {
                    { "Register Now", "http://portal.apartmentapps.com/Account/Register" }
                }
            });


        }

        protected override MarketingModuleConfig CreateDefaultConfig()
        {

            //http://www.freeformatter.com/java-dotnet-escape.html
            return new MarketingModuleConfig()
            {
                EngagementEmailTemplate = "<h1>{{Subject}}</h1><p>{{Body}}</p>",
                Enabled = true
            };
        }

        public void Execute(ILogger logger)
        {
            var userRepo = Kernel.Get<IRepository<ApplicationUser>>();

            var users = userRepo.GetAll().Where(x => !x.Archived && x.LastMobileLoginTime == null && x.LastPortalLoginTime == null).ToArray();
            foreach (var user in users)
            {
                if (user.EngagementLetterSentOn == null ||
                    DateTime.UtcNow.Subtract(user.EngagementLetterSentOn.Value).Days >= 10)
                {
                    SendUserEngagementLetter(user);
                    user.EngagementLetterSentOn = DateTime.UtcNow;
                    userRepo.Save();
                }
            }
        }

        public string SettingsController => "MarketingConfig";
    }
}