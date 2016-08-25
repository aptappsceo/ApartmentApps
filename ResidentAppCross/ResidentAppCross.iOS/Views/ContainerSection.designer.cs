// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ResidentAppCross.iOS
{
	[Register ("ContainerSection")]
	partial class ContainerSection
	{
		[Outlet]
		UIKit.UIView _container { get; set; }

		[Outlet]
		UIKit.UILabel _labe { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_labe != null) {
				_labe.Dispose ();
				_labe = null;
			}

			if (_container != null) {
				_container.Dispose ();
				_container = null;
			}
		}
	}
}
