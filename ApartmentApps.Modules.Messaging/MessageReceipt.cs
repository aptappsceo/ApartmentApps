using System.ComponentModel.DataAnnotations.Schema;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class MessageReceipt : PropertyEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User
        {
            get; set;
        }

        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }

        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public bool Opened { get; set; }
    }
}