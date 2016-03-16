using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResidentAppCross.iOS
{
	public partial class CallToActionSection : SectionViewBase
	{
		public CallToActionSection (IntPtr handle) : base (handle)
		{
		}

	    public UIButton MainButton => ActionButton;


	}
}
