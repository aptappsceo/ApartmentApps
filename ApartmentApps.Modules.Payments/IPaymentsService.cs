using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApartmentApps.Api.Modules
{
    public interface IPaymentsService
    {
        Task<MakePaymentResult> MakePayment(MakePaymentBindingModel makePaymentBindingModel);
        Task<AddCreditCardResult> AddCreditCard(AddCreditCardBindingModel addCreditCard);
        Task<AddBankAccountResult> AddBankAccount(AddBankAccountBindingModel addCreditCard);
        IEnumerable<PaymentOptionBindingModel> GetPaymentOptions();
        IEnumerable<PaymentHistoryBindingModel> GetPaymentHistory();
        Task<PaymentSummaryBindingModel> GetPaymentSummary(string userId);
        Task<PaymentSummaryBindingModel> GetRentSummary(string userId);
    }
}