using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ApartmentApps.Data;

namespace ApartmentApps.Api.Modules
{
    [Persistant]
    public class PaymentsConfig : ModuleConfig
    {
        public PaymentsConfig()
        {
           
        }
        [DisplayName("Use Url?")]
        public bool UseUrl { get; set; }

        [DisplayName("Url")]
        public string Url { get; set; }

        public string MerchantId { get; set; }
        public string MerchantPassword { get; set; }

        [DisplayName("Credit Card Convenience Fee")]
        [DataType(DataType.Currency)]
        public decimal CreditCardConvenienceFee { get; set; }

        [DisplayName("Bank Account Savings Convenience Fee")]
        [DataType(DataType.Currency)]
        public decimal BankAccountSavingsConvenienceFee { get; set; }

        [DisplayName("Bank Account Checking Convenience Fee")]
        [DataType(DataType.Currency)]
        public decimal BankAccountCheckingConvenienceFee { get; set; }



    }
}