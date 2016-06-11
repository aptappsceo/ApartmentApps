using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client.Models;
using ResidentAppCross.Commands;

namespace ResidentAppCross.ViewModels.Screens
{
    public class CommitPaymentViewModel : ViewModelBase
    {
        private PaymentOptionBindingModel _selectedPaymentOption;
        private PaymentSummary _selectedPaymentSummary;

        public PaymentOptionBindingModel SelectedPaymentOption
        {
            get { return _selectedPaymentOption; }
            set { this.SetProperty(ref _selectedPaymentOption, value); }
        }

        public PaymentSummary SelectedPaymentSummary
        {
            get { return _selectedPaymentSummary; }
            set { this.SetProperty(ref _selectedPaymentSummary, value); }
        }

        public ICommand CommitCommand => StubCommands.NoActionSpecifiedCommand(this);

    }
}
