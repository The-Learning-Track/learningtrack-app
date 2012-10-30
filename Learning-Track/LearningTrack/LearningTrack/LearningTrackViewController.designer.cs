// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("LearningTrackViewController")]
	partial class LearningTrackViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField UsernameField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField PasswordField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton LoginButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView LoginLoadingIndicator { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UsernameField != null) {
				UsernameField.Dispose ();
				UsernameField = null;
			}

			if (PasswordField != null) {
				PasswordField.Dispose ();
				PasswordField = null;
			}

			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}

			if (LoginLoadingIndicator != null) {
				LoginLoadingIndicator.Dispose ();
				LoginLoadingIndicator = null;
			}
		}
	}
}
