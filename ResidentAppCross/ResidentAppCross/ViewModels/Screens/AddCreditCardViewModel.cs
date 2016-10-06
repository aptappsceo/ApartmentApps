using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;

namespace ResidentAppCross.ViewModels.Screens
{
    public enum CreditCardType
    {
        Visa = 0,
        MasterCard = 1
    }

    public class AddCreditCardPaymentOptionViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;
        private AddCreditCardBindingModel _addCreditCardModel;
        private string _friendlyName;
        private string _month;
        private string _year;
        private string _accountHolderName;
        private string _cardNumber;
        private int _cardType;
        private string _cvcCode;


        public string FriendlyName
        {
            get { return _friendlyName; }
            set { SetProperty(ref _friendlyName, value); }
        }

        public string Month
        {
            get { return _month; }
            set { SetProperty(ref _month, value); }

        }

        public string Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }

        }

        public string AccountHolderName
        {
            get { return _accountHolderName; }
            set { SetProperty(ref _accountHolderName, value); }

        }
        public string CvcCode
        {
            get { return _cvcCode; }
            set { SetProperty(ref _cvcCode, value); }

        }

        public string CardNumber
        {
            get { return _cardNumber; }
            set { SetProperty(ref _cardNumber, value); }

        }

        public int CardType
        {
            get { return _cardType; }
            set { SetProperty(ref _cardType, value); }
        }

        public AddCreditCardPaymentOptionViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }
        
        public ICommand AddCreditCardCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await _service.Payments.AddCreditCardAsync(new AddCreditCardBindingModel()
                    {
                        AccountHolderName = AccountHolderName,
                        CardNumber = CardNumber,
                        CardType = CardType,
                        ExpirationMonth = Month,
                        ExpirationYear = Year,
                        FriendlyName = FriendlyName
                    });
                }).OnStart("Adding new payment option...").OnComplete("New credit card added!", ()=>this.Close(this));
            }
        }

    }

    public class AddBankAccountPaymentOptionViewModel : ViewModelBase
    {

        private IApartmentAppsAPIService _service;
        private AddBankAccountBindingModel _addBankAccountModel;
        private string _friendlyName;
        private string _accountHolderName;
        private string _accountNumber;
        private string _routingNumber;
        private bool _isSavings;

        public AddBankAccountPaymentOptionViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public string FriendlyName
        {
            get { return _friendlyName; }
            set { SetProperty(ref _friendlyName,value); }
        }

        public string AccountHolderName
        {
            get { return _accountHolderName; }
            set { SetProperty(ref _accountHolderName, value); }

        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { SetProperty(ref _accountNumber, value); }

        }

        public string RoutingNumber
        {
            get { return _routingNumber; }
            set { SetProperty(ref _routingNumber, value); }

        }

        public bool IsSavings
        {
            get { return _isSavings; }
            set { SetProperty(ref _isSavings, value); }

        }

        public ICommand AddBankAccountCommand
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    await _service.Payments.AddBankAccountWithOperationResponseAsync(new AddBankAccountBindingModel()
                    {
                        FriendlyName = FriendlyName,
                        AccountNumber = AccountNumber,
                        AccountHolderName = AccountHolderName,
                        IsSavings = IsSavings,
                        RoutingNumber = RoutingNumber
                    });
                }).OnStart("Adding new payment option...").OnComplete("New bank account added!", ()=>this.Close(this));
            }
        }

    }

 
}