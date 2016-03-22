using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.iOS.Views;
using ResidentAppCross.iOS.Views.Attributes;
using ResidentAppCross.iOS.Views.Sections.CollectionSections;
using ResidentAppCross.iOS.Views.TableSources;
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
