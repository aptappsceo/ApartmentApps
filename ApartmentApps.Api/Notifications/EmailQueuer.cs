using System;
using ApartmentApps.Data.Repository;
using Newtonsoft.Json;

namespace ApartmentApps.Api.NewFolder1
{
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
}