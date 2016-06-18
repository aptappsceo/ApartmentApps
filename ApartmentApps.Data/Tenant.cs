using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ApartmentApps.Data
{
    public abstract class UserEntity : PropertyEntity
    {
        [DefaultValue(1)]
        [DataType("Hidden")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [DataType("Ignore")]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
    public abstract class PropertyEntity : IPropertyEntity
    {
        [DefaultValue(1)]
        [DataType("Hidden")]
        public int? PropertyId { get; set; } = 1;

        [ForeignKey("PropertyId")]
        [DataType("Ignore")]
        [JsonIgnore]
        public virtual Property Property { get; set; }

        [Key]
        [DataType("Hidden")]
        public int Id { get; set; }
    }

    //public partial class Tenant : PropertyEntity
    //{
    //    [Key, ForeignKey("User")]
    //    public string UserId { get; set; }

    //    public virtual ApplicationUser User { get; set; }

    //    public int? UnitId { get; set; }

    //    [ForeignKey("UnitId")]
    //    public virtual Unit Unit { get; set; }

    //    public string ThirdPartyId { get; set; }

    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public string UnitNumber { get; set; }

    //    public string BuildingName { get; set; }

    //    public string Address { get; set; }

    //    public string City { get; set; }

    //    public string State { get; set; }

    //    public string PostalCode { get; set; }
        
    //    public string Email { get; set; }

    //    public string Gender { get; set; }

    //    public string MiddleName { get; set; }
    //}
}