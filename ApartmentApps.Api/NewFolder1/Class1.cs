using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string HeaderLogoImageUrl { get; set; }
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
       // [DefaultValue(1)]
        [DataType("Hidden")]
        public string UserId { get; set; }  

        [ForeignKey("UserId")]
        [DataType("Ignore")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        public DateTime? ScheduleDate { get; set; }
    }

    public class EmailQueuer 
    {
        private readonly IRepository<EmailQueueItem> _emailQueueItems;

        public EmailQueuer(IRepository<EmailQueueItem> emailQueueItems )
        {
            _emailQueueItems = emailQueueItems;
        }

        public void QueueEmail<TData>(TData data, DateTime? scheduleDate = null) where TData : EmailData
        {
            if (data == null) throw new ArgumentNullException(nameof(data),"data can't be null");
            _emailQueueItems.Add(new EmailQueueItem()
            {
                To = data.ToEmail,
                From = data.FromEmail,
                UserId = data.User.Id,
                Subject = data.Subject,
                ScheduleDate = scheduleDate,
                BodyData = JsonConvert.SerializeObject(data),
                BodyType = data.GetType().AssemblyQualifiedName
            });
            _emailQueueItems.Save();
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
