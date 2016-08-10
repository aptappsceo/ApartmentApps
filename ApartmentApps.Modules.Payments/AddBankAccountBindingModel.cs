using System.ComponentModel;

namespace ApartmentApps.Api.Modules
{
    public class AddBankAccountBindingModel
    {
        [DisplayName("Is Savings?")]
        [Description("If unchecked a checking account is used.")]
        public bool IsSavings { get; set; }

        [DisplayName("Account Holder Name")]
        public string AccountHolderName { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Routing Number")]
        public string RoutingNumber { get; set; }

        [DisplayName("Friendly Name")]
        [Description("A friendly name that you can use for this account.")]
        public string FriendlyName { get; set; }
    }
}