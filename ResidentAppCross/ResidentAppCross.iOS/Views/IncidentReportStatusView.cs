using Foundation;
using ResidentAppCross.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.ViewModels.Screens;
using UIKit;
namespace ResidentAppCross.iOS
{
	
	[Register("IncidentReportStatusView")]
	[NavbarStyling]
	[StatusBarStyling(Style = UIStatusBarStyle.BlackOpaque)]
	partial class IncidentReportStatusView : BaseForm<IncidentReportStatusViewModel>
	{

		public IncidentReportStatusView(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
		}

		public IncidentReportStatusView()
		{
		}
       
	}
	
}
