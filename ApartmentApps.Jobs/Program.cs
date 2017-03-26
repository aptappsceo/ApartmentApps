using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api;
using ApartmentApps.Api.Auth;
using ApartmentApps.Api.Modules;
using ApartmentApps.Api.NewFolder1;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using ApartmentApps.IoC;
using ApartmentApps.Modules.Inspections;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using Ninject;
using RazorEngine.Templating;

namespace ApartmentApps.Jobs
{
    class Program
    {
        static void Main(string[] args)
        {

            IKernel mainKernel = new StandardKernel();
            Register.RegisterServices(mainKernel);
            Inspection inspection = new Inspection();
            PaymentSummaryBindingModel model = new PaymentSummaryBindingModel();
            //#if DEBUG
            //            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApartmentApps.Data.Migrations.Configuration>());
            //#endif   
            var context = new ApplicationDbContext();

            //var email = true;
            //while (email)
            //{
                // Should it run continously
                var email = args.Any(p => p.Contains("email"));

                foreach (var item in context.Properties.Where(p => p.Id == 33 && p.State == PropertyState.Active).ToArray())
                {
                    IKernel kernel = new StandardKernel();
                    Register.RegisterServices(kernel);

                    kernel.Bind<DefaultUserManager>().ToSelf().InSingletonScope();
                    kernel.Bind<UserManager<ApplicationUser>>().ToSelf().InSingletonScope();
                    kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InSingletonScope();
                    var userContext = new FakeUserContext(context, kernel)
                    {
                        PropertyId = item.Id,
                        UserId = context.Users.First(p => p.UserName == "micahosborne@gmail.com").Id,
                        Email = "micahosborne@gmail.com",
                        Name = "Jobs"
                    };

                    kernel.Bind<IUserContext>().ToMethod(p => userContext);
                    kernel.Bind<ILogger>().To<ConsoleLogger>();
#if DEBUG
                    if (false)
#else
                    if (email)
#endif


                    {
                        try
                        {
                            ExecuteEmailQueue(kernel, item);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.StackTrace);
                        }
                    }
                    else
                    {
                        ExecuteNightly(kernel, item);
                    }

                }
            //}
            //var ids = new int[] {33};
            //foreach (var item in context.Properties.Where(x=>ids.Contains(x.Id)).ToArray())
          


        }

        private static void ExecuteEmailQueue(IKernel kernel, Property item)
        {
            var logger = kernel.Get<ILogger>();
            var emailQueue = kernel.Get<IRepository<EmailQueueItem>>();
            var razorService = kernel.Get<IRazorEngineService>();
            var emailService = kernel.Get<IEmailService>();
            var alertsConfigItems = kernel.Get<UserAlertsConfigProvider>();
           
            var emailItems = emailQueue.GetAll().Where(x=>!x.Error && x.PropertyId == item.Id).ToArray();
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

        private static void ExecuteNightly(IKernel kernel, Property item)
        {
#if DEBUG
            var modules = kernel.GetAll<IModule>().Where(p => p.Enabled).OfType<EntrataModule>().ToArray();
#else
                var modules = kernel.GetAll<IModule>().Where(p=>p.Enabled).OfType<IWebJob>().ToArray();
#endif
            //var strLogger = new StringLogger();
            foreach (var module in modules)
            {
                try
                {
                    module.Execute(new ConsoleLogger());
                }
                catch (Exception ex)
                {
                    kernel.Get<IEmailService>().SendAsync(new IdentityMessage()
                    {
                        Subject = $"Background Error with module: {module.GetType().Name}",
                        Body = item.Name + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace,
                        Destination = "mosborne@apartmentapps.com"
                    });
                }
            }
        }
    }

    public class StringLogger : ILogger
    {
        public override string ToString()
        {
            return base.ToString();
        }
        StringBuilder sb = new StringBuilder();

        public void Error(string str, params object[] args)
        {
            sb.AppendLine("Error: " + string.Format(str, args));
        }

        public void Warning(string str, params object[] args)
        {
            sb.AppendLine("Warning: " + string.Format(str, args));
        }

        public void Info(string str, params object[] args)
        {
            sb.AppendLine("Info: " + string.Format(str, args));
        }
    }
    //public class ConsoleLogger : ILogger
    //{
    //    public void Error(string str, params object[] args)
    //    {
    //        Console.WriteLine(str,args);
    //    }

    //    public void Warning(string str, params object[] args)
    //    {
    //        Console.WriteLine(str, args);
    //    }

    //    public void Info(string str, params object[] args)
    //    {
    //        Console.WriteLine(str, args);
    //    }
    //}

    //public class JobsUserContext : IUserContext
    //{
    //    private readonly ApplicationDbContext _dbContext;

    //    public JobsUserContext(ApplicationDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    private ApplicationUser _currentUser;

    //    public bool IsInRole(string roleName)
    //    {
    //        return true;
    //    }

    //    public string UserId { get; set; }
    //    public string Email { get; set; }
    //    public string Name { get; set; }
    //    public int PropertyId { get; set; }

    //    public void SetProperty(int propertyId)
    //    {

    //    }

    //    public ApplicationUser CurrentUser
    //    {
    //        get { return _currentUser ?? (_currentUser = _dbContext.Users.Find(UserId)); }
    //        set { _currentUser = value; }
    //    }
    //}

}
