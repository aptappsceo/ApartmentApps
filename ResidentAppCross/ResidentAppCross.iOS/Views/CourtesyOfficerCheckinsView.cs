using System;
using System.Collections.Generic;
using System.Linq;
using ApartmentApps.Client.Models;
using Cirrious.FluentLayouts.Touch;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
    [Register("CourtesyOfficerCheckinsView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class CourtesyOfficerCheckinsView : BaseForm<CourtesyOfficerCheckinsViewModel>
    {
        private MapSection _mapSection;
		private CheckinsAnnotationManager _manager;
        private HeaderSection _headerSection;
        private CallToActionSection _callToActionSection;

        public MapSection MapSection
        {
            get
            {
                if (_mapSection == null)
                {

                    _mapSection = Formals.Create<MapSection>();
                    _mapSection.MapView.Delegate = new PropertyMapViewDelegate();
                    _mapSection.MapView.MapType = MKMapType.SatelliteFlyover;
                    _mapSection.HeightConstraint.Constant = 400;
                    _mapSection.HeaderLabel.Text = "Checkin Locations";
                    CLLocationCoordinate2D coords = new CLLocationCoordinate2D(48.857, 2.351);
                    MKCoordinateSpan span = new MKCoordinateSpan(_mapSection.MilesToLatitudeDegrees(0.01), _mapSection.MilesToLongitudeDegrees(0.01, coords.Latitude));
                    _mapSection.MapView.Region = new MKCoordinateRegion(coords, span);
                    _mapSection.MapView.ShowsUserLocation = true;

                }
                return _mapSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();
            var b = this.CreateBindingSet<CourtesyOfficerCheckinsView, CourtesyOfficerCheckinsViewModel>();
            ViewModel.PropertyChanged += (sender, args) =>
            {
                MapSection.MapView.UserLocation.Coordinate =
                     new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude,
                         ViewModel.CurrentLocation.Longitude);
                MapSection.MapView.SetCenterCoordinate(new CLLocationCoordinate2D(ViewModel.CurrentLocation.Latitude, ViewModel.CurrentLocation.Longitude), false);
            };
            b.Bind(CallToActionSection.MainButton).To(vm => vm.CheckinCommand);
			_manager = new CheckinsAnnotationManager(this.MapSection.MapView);
            b.Bind(_manager).For(m => m.ItemsSource).To(vm => vm.Locations);
            // SegmentSelectionSection.Selector.ValueChanged += (sender, args) => RefreshContent();
            b.Apply();
            ViewModel.UpdateLocations.Execute(null);

        }

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.MainLabel.Text = "Courtesy Officer";
                    _headerSection.SubLabel.Text = "Checkins";
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.LocationOk, SharedResources.Size.L);
                    _headerSection.LogoImage.TintColor = AppTheme.SecondaryBackgoundColor;
                }

                return _headerSection;
            }
        }
        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            content.Add(HeaderSection);
            //content.Add(SegmentSelectionSection);
            content.Add(MapSection);
            content.Add(CallToActionSection);

            //content.Add(ButtonToolbarSection);
        }
        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.MainButton.SetTitle("Scan QR Code", UIControlState.Normal);
                }
                return _callToActionSection;
            }
        }


        //add to con
        public bool CurrentLocationUpdated { get; set; }
    }

    public class PropertyMapViewDelegate :MKMapViewDelegate
    {
        private string annotationId = "LocationAnnotationView";

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {



            if (annotation is MKUserLocation)
                return base.GetViewForAnnotation(mapView, annotation);
            var checkinAnnotation = annotation as CheckinBindingModelAnnotation;
            if (checkinAnnotation != null)
            {
                MKAnnotationView annotationView = null;
                var unCompleteIcon = AppTheme.GetIcon(SharedResources.Icons.LocationQuestion, ResidentAppCross.Resources.SharedResources.Size.S).TintBlack(AppTheme.InProgressColor);
                var completeIcon = AppTheme.GetIcon(SharedResources.Icons.LocationOk, ResidentAppCross.Resources.SharedResources.Size.S).TintBlack(AppTheme.CompleteColor);

                // show conference annotation
                annotationView = mapView.DequeueReusableAnnotation(annotationId);

                if (annotationView == null)
                    annotationView = new MKAnnotationView(annotation, annotationId);
                if (checkinAnnotation._house.Complete == true)
                {
                    annotationView.Image = completeIcon;
                }
                else
                {
                    annotationView.Image = unCompleteIcon;
                }

                annotationView.CanShowCallout = true;
                return annotationView;
            }

            return null;
            //var result =
            //result.Image = UIImage.FromBundle("MaintenaceIcon");
            //return result;
        }
    }

    [Register("AddCreditCardPaymentOptionView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class AddCreditCardPaymentOptionView : BaseForm<AddCreditCardPaymentOptionViewModel>
    {
        private TextFieldSection _paymentOptionTitleSection;
        private TextFieldSection _cardNumberSection;
        private TextFieldSection _cvcCodeSection;
        private TextFieldSection _accountHolderSection;
        private CallToActionSection _callToActionSection;
        private HeaderSection _headerSection;
        private ToggleSection _isSavingsSection;
        private TextFieldSection _yearSection;
        private TextFieldSection _monthSection;
        private SegmentSelectionSection _creditCardTypeSection;


        public SegmentSelectionSection CreditCardTypeSection
        {
            get
            {
                if (_creditCardTypeSection== null)
                {
                    _creditCardTypeSection= Formals.Create<SegmentSelectionSection>();
                    _creditCardTypeSection.Label.Text = "Credit Card Type";
                    _creditCardTypeSection.Editable = true;
                }
                return _creditCardTypeSection;
            }
        }


        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.WalletPlus, SharedResources.Size.L);
                    _headerSection.MainLabel.Text = "Add Credit Card";
                    _headerSection.SubLabel.Text = "Please, fill the information below";
                }
                return _headerSection;
            }
        }

        public TextFieldSection PaymentOptionTitleSection
        {
            get
            {
                return _paymentOptionTitleSection ?? (_paymentOptionTitleSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Payment Option Title...")
                    .WithNextResponder(CardNumberSection));
            }
        }

        public TextFieldSection CardNumberSection
        {
            get
            {
                return _cardNumberSection ?? (_cardNumberSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Card Number...")
                    .WithNextResponder(CvcCodeSection));
            }
        }

        public TextFieldSection CvcCodeSection
        {
            get
            {
                return _cvcCodeSection ?? (_cvcCodeSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("CVC Number...")
                    .WithNextResponder(MonthSection));
            }
        }

        public TextFieldSection MonthSection
        {
            get
            {
                return _monthSection ?? (_monthSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Expiration Month (ex. 02)...")
                    .WithNextResponder(YearSection));
            }
        }

        public TextFieldSection YearSection
        {
            get
            {
                return _yearSection ?? (_yearSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Expiration Year (ex. 2012)...")
                    .WithNextResponder(AccountHolderSection));
            }
        }

        public TextFieldSection AccountHolderSection
        {
            get
            {
                return _accountHolderSection ?? (_accountHolderSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Credit Card Holder Name..."));
            }
        }

        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                    _callToActionSection.MainButton.SetTitle("Add Credit Card");
                }
                return _callToActionSection;
            }
        }

        public ToggleSection IsSavingsSection
        {
            get
            {
                if (_isSavingsSection == null)
                {
                    _isSavingsSection = Formals.Create<ToggleSection>();
                    _isSavingsSection.Editable = true;
                    _isSavingsSection.HeightConstraint.Constant = 66;
                    _isSavingsSection.HeaderLabel.Text = "Is Savings?";
                    _isSavingsSection.SubHeaderLabel.Hidden = true;
                }
                return _isSavingsSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();
            var set = this.CreateBindingSet<AddCreditCardPaymentOptionView, AddCreditCardPaymentOptionViewModel>();
            set.Bind(PaymentOptionTitleSection.TextField).To(vm => vm.FriendlyName);
            set.Bind(AccountHolderSection.TextField).To(vm => vm.AccountHolderName);
            set.Bind(CardNumberSection.TextField).To(vm => vm.CardNumber);
            set.Bind(CvcCodeSection.TextField).To(vm => vm.CvcCode);
           // set.Bind(CardTypeSection.TextField).To(vm => vm.CardType);
            set.Bind(MonthSection.TextField).To(vm => vm.Month);
            set.Bind(YearSection.TextField).To(vm => vm.Year);
            CreditCardTypeSection.BindTo(((CreditCardType[])(Enum.GetValues(typeof(CreditCardType)))).ToList(),s=>s.ToString(),s=>ViewModel.CardType= (int)s, 0);
           // b.Bind(PetStatusSection.Selector).For(s => s.SelectedSegment).To(vm => vm.SelectedPetStatus);
            set.Bind(CallToActionSection.MainButton).To(vm => vm.AddCreditCardCommand);
            set.Apply();
        }


        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(PaymentOptionTitleSection);
            content.Add(CardNumberSection);
            //content.Add(CvcCodeSection);
            content.Add(MonthSection);
            content.Add(YearSection);
            content.Add(CreditCardTypeSection);
            content.Add(AccountHolderSection);
            content.Add(CallToActionSection);
        }
    }

    [Register("AddBankAccountPaymentOptionView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class AddBankAccountPaymentOptionView : BaseForm<AddBankAccountPaymentOptionViewModel>
    {
        private TextFieldSection _paymentOptionTitleSection;
        private TextFieldSection _routingNumberSection;
        private TextFieldSection _accountNumberSection;
        private TextFieldSection _accountHolderSection;
        private CallToActionSection _callToActionSection;
        private HeaderSection _headerSection;
        private ToggleSection _isSavingsSection;

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.WalletPlus, SharedResources.Size.L);
                    _headerSection.MainLabel.Text = "Add Bank Account";
                    _headerSection.SubLabel.Text = "Please, fill the information below";
                }
                return _headerSection;
            }
        }

        public TextFieldSection PaymentOptionTitleSection
        {
            get
            {
                return _paymentOptionTitleSection ?? (_paymentOptionTitleSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Payment Option Title...")
                    .WithNextResponder(AccountNumberSection));
            }
        }

        public TextFieldSection RoutingNumberSection
        {
            get
            {
                return _routingNumberSection ?? (_routingNumberSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Routing Number...")
                    .WithNextResponder(AccountHolderSection));
            }
        }

        public TextFieldSection AccountNumberSection
        {
            get
            {
                return _accountNumberSection ?? (_accountNumberSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Account Number...")
                    .WithNextResponder(RoutingNumberSection));
            }
        }

        public TextFieldSection AccountHolderSection
        {
            get
            {
                return _accountHolderSection ?? (_accountHolderSection = Formals.Create<TextFieldSection>()
                    .WithPlaceholder("Account Holder Name..."));
            }
        }

        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                    _callToActionSection.MainButton.SetTitle("Add Bank Account");
                }
                return _callToActionSection;
            }
        }

        public ToggleSection IsSavingsSection
        {
            get
            {
                if (_isSavingsSection == null)
                {
                    _isSavingsSection = Formals.Create<ToggleSection>();
                    _isSavingsSection.Editable = true;
                    _isSavingsSection.HeightConstraint.Constant = 66;
                    _isSavingsSection.HeaderLabel.Text = "Is Savings?";
                    _isSavingsSection.SubHeaderLabel.Hidden = true;
                }
                return _isSavingsSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();
            var set = this.CreateBindingSet<AddBankAccountPaymentOptionView, AddBankAccountPaymentOptionViewModel>();
            set.Bind(PaymentOptionTitleSection.TextField).To(vm => vm.FriendlyName);
            set.Bind(AccountHolderSection.TextField).To(vm => vm.AccountHolderName);
            set.Bind(AccountNumberSection.TextField).To(vm => vm.AccountNumber);
            set.Bind(RoutingNumberSection.TextField).To(vm => vm.RoutingNumber);
            set.Bind(IsSavingsSection.Switch).To(vm => vm.IsSavings);
            set.Bind(CallToActionSection.MainButton).To(vm => vm.AddBankAccountCommand);
            set.Apply();
        }


        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(PaymentOptionTitleSection);
            content.Add(AccountHolderSection);
            content.Add(AccountNumberSection);
            content.Add(RoutingNumberSection);
            content.Add(IsSavingsSection);
            content.Add(CallToActionSection);
        }
    }

    [Register("PaymentOptionsView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class PaymentOptionsView : BaseForm<PaymentOptionsViewModel>
    {
        private CallToActionSection _addCreditCardSection;
        private CallToActionSection _addBankAccountSection;
        private HeaderSection _headerSection;
        private TableSection _tableSection;
        private GenericTableSource _tableItemsSource;
        private TableDataBinding<UITableViewCell, PaymentOptionBindingModel> _tableItemsBinding;

        //Header view
        //payment options table

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.Wallet, SharedResources.Size.L);
                    _headerSection.MainLabel.Text = "Payment Options";
                    _headerSection.SubLabel.Text = "Select payment option or add a new one";
                }
                return _headerSection;
            }
        }


        public TableSection TableSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>();
                    _tableSection.Table.AllowsSelection = true;
                    _tableSection.Source = TableItemsSource;
                    _tableSection.Table.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
                    _tableSection.ReloadData();
                }
                return _tableSection;
            }
        }

        public GenericTableSource TableItemsSource
        {
            get
            {
                if (_tableItemsSource == null)
                {
                    _tableItemsSource = new GenericTableSource()
                    {
                        Items = ViewModel.PaymentOptions, //Deliver data
                        Binding = TableItemsBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true,
                    };
                }
                return _tableItemsSource;
            }
            set { _tableItemsSource = value; }
        }

        public TableDataBinding<UITableViewCell, PaymentOptionBindingModel> TableItemsBinding
        {
            get
            {
                if (_tableItemsBinding == null)
                {
                    _tableItemsBinding = new TableDataBinding<UITableViewCell, PaymentOptionBindingModel>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {
                            cell.TextLabel.Text = item.FriendlyName;
                        },
                        //CellHeight = (item, index) => { return TicketItemCell.FullHeight; },
                        ItemSelected = item =>
                        {
                            ViewModel.SelectedOption = item;
                            ViewModel.PayWithSelectedPaymentOption.Execute(null);
                        },
                        AccessoryType = item => UITableViewCellAccessory.DisclosureIndicator, //What is displayed on the right edge
                        CellSelector = () => new UITableViewCell(UITableViewCellStyle.Default,"PaymentOptions_CellView"), //Define how to create cell, if reusables not found
                        CellIdentifier = "PaymentOptions_CellView"
                    };
                }
                return _tableItemsBinding;
            }
            set { _tableItemsBinding = value; }
        }

        public CallToActionSection AddCreditCardSection
        {
            get
            {
                if (_addCreditCardSection == null)
                {
                    _addCreditCardSection = Formals.Create<CallToActionSection>();
                    _addCreditCardSection.MainButton.SetTitle("Add Credit Card");
                    _addCreditCardSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                }
                return _addCreditCardSection;
            }
        }

        public CallToActionSection AddBankAccountSection
        {
            get
            {
                if (_addBankAccountSection == null)
                {
                    _addBankAccountSection = Formals.Create<CallToActionSection>();
                    _addBankAccountSection.MainButton.SetTitle("Add Bank Account");
                    _addBankAccountSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                }
                return _addBankAccountSection;
            }
        }

        public override void BindForm()
        {
            base.BindForm();
            this.OnViewModelEventMainThread<PaymentOptionsUpdated>(evt =>
            {
                TableSection.ReloadData();
            });

            var set = this.CreateBindingSet<PaymentOptionsView, PaymentOptionsViewModel>();
            set.Bind(AddCreditCardSection.MainButton).To(vm => vm.AddCreditCardCommand);
            set.Bind(AddBankAccountSection.MainButton).To(vm => vm.AddBankAccountCommand);
            set.Apply();

            SectionContainerGesturesEnabled = false;

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ViewModel.UpdatePaymentOptions.Execute(null);
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(TableSection);
            content.Add(AddCreditCardSection);
            content.Add(AddBankAccountSection);
        }

        public override void LayoutContent()
        {
            View.AddConstraints(
                HeaderSection.AtTopOf(View),
                HeaderSection.AtLeftOf(View),
                HeaderSection.AtRightOf(View)
                );


            View.AddConstraints(
                TableSection.Below(HeaderSection),
                TableSection.AtLeftOf(View),
                TableSection.AtRightOf(View)
                );

            View.AddConstraints(
                AddCreditCardSection.Below(TableSection),
                AddCreditCardSection.AtLeftOf(View),
                AddCreditCardSection.AtRightOf(View)
                );

            View.AddConstraints(
                AddBankAccountSection.Below(AddCreditCardSection),
                AddBankAccountSection.AtLeftOf(View),
                AddBankAccountSection.AtRightOf(View),
                AddBankAccountSection.AtBottomOf(View)
                );
        }

    }

    [Register("CommitPaymentView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class CommitPaymentView : BaseForm<CommitPaymentViewModel>
    {
        private HeaderSection _headerSection;
        private CallToActionSection _callToActionSection;
        private GenericTableSection _paymentSummarySection;
        private TableDataBinding<PaymentSummaryViewCell, PaymentSummaryEntry> _tableItemsBinding;
        private TableSection _tableSection;
        private GenericTableSource _tableFiltersSource;


        public CallToActionSection CallToActionSection
        {
            get
            {
                if (_callToActionSection == null)
                {
                    _callToActionSection = Formals.Create<CallToActionSection>();
                    _callToActionSection.MainButton.SetTitle("Commit Payment");
                    _callToActionSection.HeightConstraint.Constant = AppTheme.CallToActionSectionHeight;
                }
                return _callToActionSection;
            }
        }

        public TableSection TableSection
        {
            get
            {
                if (_tableSection == null)
                {
                    _tableSection = Formals.Create<TableSection>();
                    _tableSection.Table.ContentInset = new UIEdgeInsets(8, 24, 8, 24);
                    _tableSection.Table.AllowsSelection = false;
                    _tableSection.Source = TableItemsSource;
                    _tableSection.Table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                    _tableSection.ReloadData();
                }
                return _tableSection;
            }
        }

        public GenericTableSource TableItemsSource
        {
            get
            {
                if (_tableFiltersSource == null)
                {
                    _tableFiltersSource = new GenericTableSource()
                    {
                        Items = ViewModel.SelectedPaymentSummary.Entries, //Deliver data
                        Binding = TableItemsBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };
                }
                return _tableFiltersSource;
            }
            set { _tableFiltersSource = value; }
        }

        public HeaderSection HeaderSection
        {
            get
            {
                if (_headerSection == null)
                {
                    _headerSection = Formals.Create<HeaderSection>();
                    _headerSection.HeightConstraint.Constant = AppTheme.HeaderSectionHeight;
                    _headerSection.LogoImage.Image = AppTheme.GetTemplateIcon(SharedResources.Icons.Wallet, SharedResources.Size.L);
                    _headerSection.MainLabel.Text = "Rent Summary";
                    _headerSection.SubLabel.Text = "Pending payments are listed below";
                }
                return _headerSection;
            }
        }


        public TableDataBinding<PaymentSummaryViewCell, PaymentSummaryEntry> TableItemsBinding
        {
            get
            {
                if (_tableItemsBinding == null)
                {
                    _tableItemsBinding = new TableDataBinding<PaymentSummaryViewCell, PaymentSummaryEntry>() //Define cell type and data type as type args
                    {
                        Bind = (cell, item, index) => //What to do when cell is created for item
                        {

                            cell.ItemPriceLabel.Text = item.Price;
                            cell.ItemTitleLabel.Text = item.Title;

                            if (item.Format == PaymentSummaryFormat.Default)
                            {
                                cell.TopSeparator.Alpha = 0;
                                cell.BottomSeparator.Alpha = 1;
                            }
                            else
                            {
                                cell.TopSeparator.Alpha = 1;
                                cell.BottomSeparator.Alpha = 0;
                            }

                        },
                        //CellHeight = (item, index) => { return TicketItemCell.FullHeight; },
                        ItemSelected = item =>
                        {
                            //ViewModel.SelectedRequest = item;
                            //ViewModel.OpenSelectedRequestCommand.Execute(null);
                        }, //When accessory button clicked
                        AccessoryType = item => UITableViewCellAccessory.None, //What is displayed on the right edge
                        //CellSelector = () => new PaymentSummaryViewCell(), //Define how to create cell, if reusables not found
                        CellIdentifier = PaymentSummaryViewCell.Key
                    };
                }
                return _tableItemsBinding;
            }
            set { _tableItemsBinding = value; }
        }

        public override void BindForm()
        {
            base.BindForm();
            TableSection.Table.RegisterNibForCellReuse(PaymentSummaryViewCell.Nib, PaymentSummaryViewCell.Key);

            var set = this.CreateBindingSet<CommitPaymentView, CommitPaymentViewModel>();
            set.Bind(CallToActionSection.MainButton).To(vm => vm.CommitCommand);
            set.Apply();


        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            content.Add(TableSection);
            content.Add(CallToActionSection);
        }

        public override void LayoutContent()
        {
            View.AddConstraints(
                HeaderSection.AtTopOf(View),
                HeaderSection.AtLeftOf(View),
                HeaderSection.AtRightOf(View)
                );


            View.AddConstraints(
                TableSection.Below(HeaderSection),
                TableSection.AtLeftOf(View),
                TableSection.AtRightOf(View)
                );

            View.AddConstraints(
                CallToActionSection.Below(TableSection),
                CallToActionSection.AtLeftOf(View),
                CallToActionSection.AtRightOf(View),
                CallToActionSection.AtBottomOf(View)
                );
        }
    }






}
