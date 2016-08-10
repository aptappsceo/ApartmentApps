namespace ApartmentApps.Api.Modules
{
    public class AddCreditCardBindingModel
    {
        public string AccountHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public CardType CardType { get; set; }
        public string FriendlyName { get; set; }
    }
}