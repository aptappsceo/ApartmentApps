using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Input;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using ResidentAppCross.Commands;
using ResidentAppCross.Extensions;

namespace ResidentAppCross.ViewModels.Screens
{
    public class RentSummaryViewModel : ViewModelBase
    {
        private string _totalFormatted;
        private PaymentSummary _paymentSummary;
        private IApartmentAppsAPIService _service;

        public RentSummaryViewModel(IApartmentAppsAPIService service)
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
                    PaymentSummary.AddEntry("Some Payment Fee", "$25", PaymentSummaryFormat.Default);
                    PaymentSummary.AddEntry("Some Discount", "$25", PaymentSummaryFormat.Discount);
                    PaymentSummary.AddEntry("Total", "$250", PaymentSummaryFormat.Total);
                    
                    this.Publish(new RentSummaryUpdated(this));

                }).OnStart("Fetching Rent Summary...");
            }
        }

    }

   

    public class RentSummaryUpdated : MvxMessage
    {
        public RentSummaryUpdated(object sender) : base(sender)
        {
        }
    }

    public class PaymentOptionsUpdated : MvxMessage
    {
        public PaymentOptionsUpdated(object sender) : base(sender)
        {
        }
    }

    public class PaymentOptionsViewModel : ViewModelBase
    {

        private ObservableCollection<PaymentOptionBindingModel> _paymentOptions;
        private IApartmentAppsAPIService _service;
        private PaymentSummary _paymentSummary;

        public PaymentOptionsViewModel(IApartmentAppsAPIService service)
        {
            _service = service;
        }

        public ObservableCollection<PaymentOptionBindingModel> PaymentOptions
        {
            get { return _paymentOptions ?? (_paymentOptions = new ObservableCollection<PaymentOptionBindingModel>()); }
            set { _paymentOptions = value; }
        }

        public override void Start()
        {
            base.Start();
            UpdatePaymentOptions.Execute(null);
        }

        public PaymentOptionBindingModel SelectedOption { get; set; }

        public ICommand PayWithSelectedPaymentOption => new MvxCommand(() =>
        {
            ShowViewModel<CommitPaymentViewModel>(vm =>
            {
                vm.SelectedPaymentOption = SelectedOption;
                vm.SelectedPaymentSummary = PaymentSummary;
            });
        });

        public ICommand UpdatePaymentOptions => this.TaskCommand(async ctx =>
        {
            PaymentOptions.Clear();
            var opts = await _service.Payments.GetPaymentOptionsAsync();
            PaymentOptions.AddRange(opts);
            this.Publish(new PaymentOptionsUpdated(this));
        }).OnStart("Fetching payment options...");

        public ICommand AddCreditCardCommand => new MvxCommand(()=>ShowViewModel<AddCreditCardPaymentOptionViewModel>());
        public ICommand AddBankAccountCommand => new MvxCommand(()=>ShowViewModel<AddBankAccountPaymentOptionViewModel>());

        public PaymentSummary PaymentSummary
        {
            get { return _paymentSummary; }
            set { SetProperty(ref _paymentSummary, value); }
        }
    }

    public class PaymentSummary
    {
        private ObservableCollection<PaymentSummaryEntry> _entries;

        public ObservableCollection<PaymentSummaryEntry> Entries
        {
            get { return _entries ?? (_entries = new ObservableCollection<PaymentSummaryEntry>()); }
            set { _entries = value; }
        }

        public void AddEntry(string title, string price, PaymentSummaryFormat format)
        {
            Entries.Add(new PaymentSummaryEntry()
            {
                Title = title,
                Price = price,
                Format = format
            }); 
        }

        public void Clear()
        {
            Entries.Clear();
        }
    }

    public class PaymentSummaryEntry
    {
        public string Title { get; set; }
        public string Price { get; set; }
        public PaymentSummaryFormat Format { get; set; }
    }

    public enum PaymentSummaryFormat
    {
        Default,
        Discount,
        Total
    }

    public class PaymentActionMock
    {
        public string Name { get; set; }
        public string Verb { get; set; }
        public Action Action { get; set; }
    }
}