using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using ResidentAppCross.Commands;

namespace ResidentAppCross.ViewModels.Screens
{
    public class CommitPaymentViewModel : ViewModelBase
    {
        private PaymentOptionBindingModel _selectedPaymentOption;
        private PaymentSummary _selectedPaymentSummary;
        private IApartmentAppsAPIService _service;

        public CommitPaymentViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public override void Start()
        {
            base.Start();
            UpdateRentSummary.Execute(null);
        }

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

        public ICommand CommitCommand => this.TaskCommand(async ctx =>
        {

            await _service.Payments.MakePaymentAsync(new MakePaymentBindingModel()
            {
                PaymentOptionId = SelectedPaymentOption.Id.ToString()
            });

        }).OnStart("Processing...").OnComplete("Payment has been commited!");

        public ICommand UpdateRentSummary
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    var items = await _service.Payments.GetPaymentSummaryAsync(SelectedPaymentOption.Id.Value);
                    SelectedPaymentSummary.Clear();
                    foreach (var item in items.Items)
                    {
                        SelectedPaymentSummary.AddEntry(item.Title,item.Price,(PaymentSummaryFormat)(item.Format ?? 0));
                    }
                    this.Publish(new RentSummaryUpdated(this));
                }).OnStart("Fetching Payment Summary...");
            }
        }

    }
}
