// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("PickClassViewController")]
	partial class PickClassViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem ContinueButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView classTable { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem LogoutButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView LoadingIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView LogoutIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel myLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ContinueButton != null) {
				ContinueButton.Dispose ();
				ContinueButton = null;
			}

			if (classTable != null) {
				classTable.Dispose ();
				classTable = null;
			}

			if (LogoutButton != null) {
				LogoutButton.Dispose ();
				LogoutButton = null;
			}

			if (LoadingIndicator != null) {
				LoadingIndicator.Dispose ();
				LoadingIndicator = null;
			}

			if (LogoutIndicator != null) {
				LogoutIndicator.Dispose ();
				LogoutIndicator = null;
			}

			if (myLabel != null) {
				myLabel.Dispose ();
				myLabel = null;
			}
		}
	}
}
