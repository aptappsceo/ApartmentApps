using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Data;
using ApartmentApps.Data.Repository;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace ApartmentApps.Api.NewFolder1
{
    public class EmailData
    {
        //public AlertsModuleConfig Config { get; set; }
        //public IUserContext UserContext { get; set; }

        public Dictionary<string, string> Links { get; set; } = new Dictionary<string, string>();
        public UserBindingModel User { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }

    }
    [Persistant]
    public class EmailQueueItem : PropertyEntity
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string BodyType { get; set; }
        public string BodyData { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public string ErorrStackTrace { get; set; }
    }

    public class EmailQueuer 
    {
        private readonly IRepository<EmailQueueItem> _emailQueueItems;

        public EmailQueuer(IRepository<EmailQueueItem> emailQueueItems )
        {
            _emailQueueItems = emailQueueItems;
        }

        public void QueueEmail<TData>(TData data) where TData : EmailData
        {
            _emailQueueItems.Add(new EmailQueueItem()
            {
                To = data.ToEmail,
                From = data.FromEmail,
                Subject = data.Subject,
                BodyData = JsonConvert.SerializeObject(data),
                BodyType = typeof(TData).AssemblyQualifiedName
            });
        }
    }
    //[Persistant]
    //public class ContinuousJobSchedule
    //{
    //    public string JobType { get; set; }
    //    public DateTime StartTime { get; set; }
    //    public DateTime? CompletionTime { get; set; }

    //    public string SerializedData { get; set; }

    //    public bool Error { get; set; }
    //    public string ErrorMessage { get; set; }
    //    public string ErrorStackTrace { get; set; }
    //}

    //public interface IContinousExecution<TData>
    //{
        
    //}
    public class Class1
    {
    }
}
