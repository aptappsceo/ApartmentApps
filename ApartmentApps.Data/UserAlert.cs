using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentApps.Data
{
    public class UserAlert : PropertyEntity
    {

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Type { get; set; }

        public int RelatedId { get; set; }
        public bool HasRead { get; set; }
    }
}