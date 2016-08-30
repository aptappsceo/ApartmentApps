using System.ComponentModel;

namespace ApartmentApps.Api.Modules
{
    public class AddCreditCardBindingModel
    {
        [DisplayName("Name On Card")]
        public string AccountHolderName { get; set; }
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }
        [DisplayName("Month"), Description("Example: 01")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Year"), Description("Example: 17")]
        public string ExpirationYear { get; set; }


        public string ExpirationDate => ExpirationMonth + ExpirationYear;

        [DisplayName("Card Type")]
        public CardType CardType { get; set; }
        [DisplayName("Friendly Name"), Description("The name that you can use to identify this card.")]
        public string FriendlyName { get; set; }
    }
}