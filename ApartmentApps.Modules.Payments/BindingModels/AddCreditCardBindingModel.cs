using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;
using ApartmentApps.Api.ViewModels;
using ApartmentApps.Forms;

namespace ApartmentApps.Api.Modules
{
    public class AddCreditCardBindingModel
    {

        [DisplayName("User to bind the credit card")]
        [Description("Card will be bound to current user if noone is specified")]
        [SelectFrom(nameof(Users))]
        public string UserId { get; set; }
        
        [DisplayName("Friendly Name"), Description("The name that you can use to identify this card.")]
        [Required]
        public string FriendlyName { get; set; }

        [DisplayName("Name On Card")]
        [Required]
        public string AccountHolderName { get; set; }

        [DisplayName("Card Number")]
        [Required]
        public string CardNumber { get; set; }

        [DisplayName("Month"), Description("Example: 01")]
        [Required]
        public string ExpirationMonth { get; set; }

        [DisplayName("Year"), Description("Example: 2017")]
        [Required]
        public string ExpirationYear { get; set; }

        [DisplayName("Card Type")]
        [Required]
        public CardType CardType { get; set; }



        [AutoformIgnore]
        public string ExpirationDate => ExpirationYear + ExpirationMonth;
        
        public List<UserLookupBindingModel> Users { get; set; }
    }
}