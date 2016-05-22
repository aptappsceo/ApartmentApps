using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Plugins.Messenger;

namespace ResidentAppCross.ViewModels.Screens
{
    public class RentSummaryViewModel : ViewModelBase
    {
        private string _totalFormatted;
        private PaymentSummary _paymentSummary;


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

        public ICommand UpdateRentSummary
        {
            get
            {
                return this.TaskCommand(async context =>
                {
                    PaymentSummary.Clear();

                    await Task.Delay(1000);
                    /*
                    for (int i = 0; i < 5; i++)
                    {
                        PaymentSummary.AddEntry("Some Item "+i,"$50",PaymentSummaryFormat.Default);
                    }
                    PaymentSummary.AddEntry("Total", "$250", PaymentSummaryFormat.Total);
                    */
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

    public class PaymentOptionsViewModel
    {

        private ObservableCollection<PaymentActionMock> _paymentOptions;

        public ObservableCollection<PaymentActionMock> PaymentOptions
        {
            get { return _paymentOptions ?? (_paymentOptions = new ObservableCollection<PaymentActionMock>()); }
            set { _paymentOptions = value; }
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