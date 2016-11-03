using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Data;
using ApartmentApps.Forms;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class PaymentsConfig : ModuleConfig
    {
        public PaymentsConfig()
        {
           
        }
        [DisplayName("Use Url instead of integrated system?")]
        [ToggleCategory("UseUrlCategory")]
        public bool UseUrl { get; set; }

        [DisplayName("Url to be used")]
        [WithCategory("UseUrlCategory")]
        public string Url { get; set; }

        [DisplayName("Forte Merchant ID")]
        public string MerchantId { get; set; }


        [DisplayName("Forte Merchant Password")]
        [DataType(DataType.Password)]
        public string MerchantPassword { get; set; }

        [DisplayName("Visa Card Convenience Fee")]
        [DataTypePercentage]
        [Description("As % from subtotal")]
        public decimal VisaConvenienceFee { get; set; }

        [DisplayName("Mastercard Convenience Fee")]
        [DataTypePercentage]
        [Description("As % from subtotal")]
        public decimal MastercardConvenienceFee { get; set; }

        [DisplayName("Discover Card Convenience Fee")]
        [Description("As % from subtotal")]
        [DataTypePercentage]
        public decimal DiscoverConvenienceFee { get; set; }

        [DisplayName("American Express Convenience Fee")]
        [Description("As % from subtotal")]
        [DataTypePercentage]
        public decimal AmericanExpressConvenienceFee { get; set; }

        [DisplayName("Bank Account Savings Convenience Fee")]
        [DataType(DataType.Currency)]
        public decimal BankAccountSavingsConvenienceFee { get; set; }

        [DisplayName("Bank Account Checking Convenience Fee")]
        [DataType(DataType.Currency)]
        public decimal BankAccountCheckingConvenienceFee { get; set; }



    }
}