using System;
using System.Collections.Generic;
using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels;
using ResidentAppCross.ViewModels.Screens;

namespace ResidentAppCross.iOS.Views
{

    [Register("CheckingFormView")]
    [NavbarStyling]
    [StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
    public class CheckingFormView : BaseForm<CheckingFormViewModel> 
    {
        private bool hidden;
        private ExampleSectionView _form1;
        private ExampleSectionView _form2;
        private ExampleSectionView _form5;
        private ExampleSectionView _form3;
        private ExampleSectionView _form4;

        public CheckingFormView()
        {
        }

        public override void BindForm()
        {
            base.BindForm();
            Form1.SetHeaderLabelText("Woop Woop");   
            Form2.SetHeaderLabelText("Section2");   
            Form3.SetHeaderLabelText("Something Else");   
            Form4.SetHeaderLabelText("Finally");   
            Form5.SetHeaderLabelText("Whhooot");   
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }

        public ExampleSectionView Form1
        {
            get
            {
                if (_form1 == null)
                {
                    _form1 = Formals.Create<ExampleSectionView>();
                    _form1.HeightConstraint.Constant = 200;
                }
                return _form1;
            }
        }
        public ExampleSectionView Form2
        {
            get
            {
                if (_form2 == null)
                {
                    _form2 = Formals.Create<ExampleSectionView>();
                    _form2.HeightConstraint.Constant = 200;

                }
                return _form2;
            }
        }
        public ExampleSectionView Form3
        {
            get
            {
                if (_form3 == null)
                {
                    _form3 = Formals.Create<ExampleSectionView>();
                    _form3.HeightConstraint.Constant = 200;

                }
                return _form3;
            }
        }
        public ExampleSectionView Form4
        {
            get
            {
                if (_form4 == null)
                {
                    _form4 = Formals.Create<ExampleSectionView>();
                    _form4.HeightConstraint.Constant = 200;

                }
                return _form4;
            }
        }
        public ExampleSectionView Form5
        {
            get
            {
                if (_form5 == null)
                {
                    _form5 = Formals.Create<ExampleSectionView>();
                    _form5.HeightConstraint.Constant = 200;

                }
                return _form5;
            }
        }

        public override void GetContent(List<UIView> content)
        {
            base.GetContent(content);

            Button = new UIButton().WithHeight(60f);
            Button.SetTitle("Toggle", UIControlState.Disabled | UIControlState.Focused | UIControlState.Normal | UIControlState.Highlighted | UIControlState.Reserved | UIControlState.Selected);
            Button.TitleLabel.SizeToFit();
            Button.TranslatesAutoresizingMaskIntoConstraints = false;
            Button.WithHeight(20);
            Button.TouchUpInside += (sender, args) =>
            {
                hidden = !hidden;
                RefreshContent();
            };
            content.Add(Button);
          
            if (!hidden)
            {
                content.Add(Form1);
            }
            content.Add(Form2);
            content.Add(Form3);
            content.Add(Form4);
            content.Add(Form5);

        }


        public UIButton Button { get; set; }

        public CheckingFormView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }
    }

    public class BaseForm<T> : ViewBase<T> where T : ViewModelBase
    {
        private UIScrollView _sectionsContainer;

        public BaseForm(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public BaseForm() : base (null,null)
		{
        }

        public UIScrollView SectionsContainer
        {
            get
            {
                if (_sectionsContainer == null)
                {
                    EdgesForExtendedLayout = UIRectEdge.None;
                    View.BackgroundColor = AppTheme.PrimaryForegroundColor;

                    _sectionsContainer = new UIScrollView().AddTo(View);
                    _sectionsContainer.TranslatesAutoresizingMaskIntoConstraints = false;
                    View.AddConstraints(
                            _sectionsContainer.WithSameWidth(View),
                            _sectionsContainer.WithSameHeight(View),
                            _sectionsContainer.AtTopOf(View),
                            _sectionsContainer.AtLeftOf(View)
                        );
                }
                return _sectionsContainer;
            }
            set { _sectionsContainer = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindForm();
            RefreshContent();
        }

        public virtual void BindForm()
        {
        }

        public virtual void UnbindForm()
        {
        }

        public virtual void RefreshContent()
        {

            foreach (var subview in SectionsContainer.Subviews)
            {
                subview.RemoveFromSuperview();
            }

            SectionsContainer.RemoveConstraints(SectionsContainer.Constraints);

            List<UIView> content = new List<UIView>();
            GetContent(content);

            foreach (var uiView in content)
            {
                SectionsContainer.Add(uiView);
            }

            var constraints = SectionsContainer.VerticalStackPanelConstraints(
                                           new Margins(0, 0, 0, 20, 0, 15),
                                           SectionsContainer.Subviews);

            SectionsContainer.AddConstraints(constraints);

        }

        public virtual void GetContent(List<UIView> content)
        {
            
        }

    }
}