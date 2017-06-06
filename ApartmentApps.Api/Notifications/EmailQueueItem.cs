using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;
using Newtonsoft.Json;

namespace ApartmentApps.Api.NewFolder1
{
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
}