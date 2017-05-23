using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ApartmentApps.Api;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Ninject;
using RazorEngine.Templating;

namespace ApartmentApps.Portal.Controllers
{
    public class EmailPreviewController : AAController
    {
        public EmailPreviewController(IKernel kernel, PropertyContext context, IUserContext userContext) : base(kernel, context, userContext)
        {
        }

        public ActionResult SendPreview()
        {
            var cModule = Kernel.Get<CourtesyModule>();
            cModule.SendEmail(UserContext.Now);
            return this.Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FlushEmailQueue()
        {
            var logger = Kernel.Get<ILogger>();
            var emailQueue = Kernel.Get<IRepository<EmailQueueItem>>();
            var razorService = Kernel.Get<IRazorEngineService>();
            var emailService = Kernel.Get<IEmailService>();
            var alertsConfigItems = Kernel.Get<UserAlertsConfigProvider>();
            var date = UserContext.Now;
            var property = this.PropertyId;
            var emailItems = emailQueue.GetAll().Where(x => !x.Error && x.PropertyId == property && (x.ScheduleDate == null || x.ScheduleDate <= date)).ToArray();
            foreach (var emailItem in emailItems)
            {
                var config = alertsConfigItems.ConfigForUser(emailItem.UserId);
                if (!config.EmailNotifications)
                {
                    emailQueue.Remove(emailItem);
                    emailQueue.Save();
                    continue;
                }
                var templateType = Type.GetType(emailItem.BodyType);
                var templateName = templateType.Name;
                var templateData = JsonConvert.DeserializeObject(emailItem.BodyData, templateType) as EmailData;


                if (!razorService.IsTemplateCached(templateName, templateType))
                {
                    razorService.AddTemplate(templateName,
                        LoadHtmlFile($"ApartmentApps.Modules.Alerts.EmailTemplates.{templateName}.cshtml"));
                }

                var emailBody = razorService.RunCompile(templateName, templateType, templateData);
                if (emailBody != null)
                {
                    try
                    {

                        emailService.SendAsync(new IdentityMessage()
                        {
                            Body = emailBody,
                            Destination = emailItem.To,
                            Subject = emailItem.Subject,
                        }).Wait();
                        // Only remove if successfull
                        //emailQueue.Remove(emailItem);
                        //emailQueue.Save();
                    }
                    catch (Exception ex)
                    {
                        emailItem.Error = true;
                        emailItem.ErrorMessage = ex.Message;
                        emailItem.ErorrStackTrace = ex.StackTrace;
                        emailQueue.Save();
                    }
                    finally
                    {

                    }

                }
                emailQueue.Remove(emailItem);
                emailQueue.Save();
            }
            return this.Json(true, JsonRequestBehavior.AllowGet);
        }
        private static string LoadHtmlFile(string resourceName)
        {
            using (Stream stream = typeof(AlertsModule).Assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}