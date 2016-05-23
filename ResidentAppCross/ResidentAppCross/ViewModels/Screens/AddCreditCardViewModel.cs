using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;

namespace ResidentAppCross.ViewModels.Screens
{
    public class AddCreditCardPaymentOptionViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;
        private AddCreditCardBindingModel _addCreditCardModel;

        public AddCreditCardPaymentOptionViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public AddCreditCardBindingModel AddCreditCardModel
        {
            get { return _addCreditCardModel; }
            set { SetProperty(ref _addCreditCardModel, value); }
        }

        public ICommand AddCreditCardCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await _service.Payments.AddCreditCardWithOperationResponseAsync(AddCreditCardModel);
                }).OnStart("Adding new payment option...").OnComplete("New credit card added!", ()=>this.Close(this));
            }
        }

    }

    public class AddBankAccountPaymentOptionViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;
        private AddBankAccountBindingModel _addBankAccountModel;

        public AddBankAccountPaymentOptionViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public AddBankAccountBindingModel AddBankAccountModel
        {
            get { return _addBankAccountModel; }
            set { SetProperty(ref _addBankAccountModel, value); }
        }

        public ICommand AddCreditCardCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await _service.Payments.AddBankAccountWithOperationResponseAsync(AddBankAccountModel);
                }).OnStart("Adding new payment option...").OnComplete("New bank account added!", ()=>this.Close(this));
            }
        }

    }

 
}