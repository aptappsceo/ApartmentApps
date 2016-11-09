using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.TableSources;
using ResidentAppCross.Resources;
using ResidentAppCross.ViewModels.Screens;
using UIKit;

namespace ResidentAppCross.iOS
{
    [Register("RentSummaryView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class RentSummaryView : BaseForm<RentSummaryViewModel>
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
                    _callToActionSection.MainButton.SetTitle("Pay Now");
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
                        Items = ViewModel.PaymentSummary.Entries, //Deliver data
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
                    _headerSection.LogoImage.TintColor = AppTheme.CreateColor;
                    _headerSection.MainLabel.Text = "Rent Summary";
                    _headerSection.SubLabel.Text = ViewModel.PaymentSummary.IsEmpty() ? "Nothing to pay at the moment" : "Pending payments are listed below";
                }
                return _headerSection;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ViewModel.UpdateRentSummary.Execute(null);
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
            this.OnViewModelEventMainThread<RentSummaryUpdated>(evt =>
            {
                TableSection.ReloadData();
                if (ViewModel.PaymentSummary.IsEmpty())
                {
                    HeaderSection.SubLabel.Text = "Nothing to pay at the moment";
                }
                else
                {
                     HeaderSection.SubLabel.Text = "Pending payments are listed below";
                }
                RefreshContent();
            });


            var set = this.CreateBindingSet<RentSummaryView, RentSummaryViewModel>();
            set.Bind(CallToActionSection.MainButton).To(vm => vm.CheckOutCommand);
            set.Apply();
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            if (!ViewModel.PaymentSummary.IsEmpty())
            {
                content.Add(TableSection);
                content.Add(CallToActionSection);
            }
        }

        public override void LayoutContent()
        {
            View.AddConstraints(
                HeaderSection.AtTopOf(View),
                HeaderSection.AtLeftOf(View),
                HeaderSection.AtRightOf(View)
                );

            if (!ViewModel.PaymentSummary.IsEmpty())
            {

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

    [Register("PaymentSummaryView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public partial class PaymentSummaryView : BaseForm<PaymentSummaryViewModel>
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
                    _callToActionSection.MainButton.SetTitle("Pay Now");
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
                        Items = ViewModel.PaymentSummary.Entries, //Deliver data
                        Binding = TableItemsBinding, //Deliver binding
                        ItemsEditableByDefault = true, //Set all items editable
                        ItemsFocusableByDefault = true
                    };
                }
                return _tableFiltersSource;
            }
            set { _tableFiltersSource = value; }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ViewModel.UpdateRentSummary.Execute(null);
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
                    _headerSection.LogoImage.TintColor = AppTheme.CreateColor;
                    _headerSection.MainLabel.Text = "Rent Summary";
                    _headerSection.SubLabel.Text = ViewModel.PaymentSummary.IsEmpty() ? "Nothing to pay at the moment" : "Pending payments are listed below" ;
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
            this.OnViewModelEventMainThread<RentSummaryUpdated>(evt =>
            {
                TableSection.ReloadData();
                 if (ViewModel.PaymentSummary.IsEmpty())
                {
                    HeaderSection.SubLabel.Text = "Nothing to pay at the moment";
                }
                else
                {
                     HeaderSection.SubLabel.Text = "Pending payments are listed below";
                }
                RefreshContent();
            });
            
            SectionContainerGesturesEnabled = false;

            var set = this.CreateBindingSet<PaymentSummaryView, PaymentSummaryViewModel>();
            set.Bind(CallToActionSection.MainButton).To(vm => vm.CheckOutCommand);
            set.Apply();

        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);
            content.Add(HeaderSection);
            if (!ViewModel.PaymentSummary.IsEmpty())
            {
                content.Add(TableSection);
                content.Add(CallToActionSection);
            }
        }

        public override void LayoutContent()
        {
            View.AddConstraints(
                HeaderSection.AtTopOf(View),
                HeaderSection.AtLeftOf(View),
                HeaderSection.AtRightOf(View)
                );

            if (!ViewModel.PaymentSummary.IsEmpty())
            {

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
}