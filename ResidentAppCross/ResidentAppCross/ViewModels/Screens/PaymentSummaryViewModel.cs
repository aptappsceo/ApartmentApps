using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using MvvmCross.Core.ViewModels;

namespace ResidentAppCross.ViewModels.Screens
{
   public class PaymentSummaryViewModel : ViewModelBase
    {
        private string _totalFormatted;
        private PaymentSummary _paymentSummary;
        private IApartmentAppsAPIService _service;

        public PaymentSummaryViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public override void Start()
        {
            base.Start();
            UpdateRentSummary.Execute(null);
        }

        public PaymentSummary PaymentSummary
        {
            get { return _paymentSummary ?? (_paymentSummary = new PaymentSummary()); }
            set { _paymentSummary = value; }
        }

        public ICommand CheckOutCommand
        {
            get
            {
                return  new MvxCommand(() =>
                {
                    ShowViewModel<PaymentOptionsViewModel>(vm =>
                    {
                        vm.PaymentSummary = PaymentSummary;
                    });
                });
            }
        }

        public ICommand UpdateRentSummary
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    PaymentSummary.Clear();

                    await Task.Delay(1000);
                    
                    for (int i = 0; i < 5; i++)
                    {
                        PaymentSummary.AddEntry("Some Item "+i,"$50",PaymentSummaryFormat.Default);
                    }
                    PaymentSummary.AddEntry("Total", "$250", PaymentSummaryFormat.Total);
                    
                    this.Publish(new RentSummaryUpdated(this));

                }).OnStart("Fetching Rent Summary...");
            }
        }

    }
}
