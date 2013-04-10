// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("InstructorOptionsViewController")]
	partial class InstructorOptionsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton changeClassButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ClearSeatsButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView LoadingIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel myLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (changeClassButton != null) {
				changeClassButton.Dispose ();
				changeClassButton = null;
			}

			if (ClearSeatsButton != null) {
				ClearSeatsButton.Dispose ();
				ClearSeatsButton = null;
			}

			if (LoadingIndicator != null) {
				LoadingIndicator.Dispose ();
				LoadingIndicator = null;
			}

			if (myLabel != null) {
				myLabel.Dispose ();
				myLabel = null;
			}
		}
	}
}
