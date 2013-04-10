// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("InstructorSeatingChartViewController")]
	partial class InstructorSeatingChartViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView SeatWebView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RefreshButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView LoadingIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel myLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SeatWebView != null) {
				SeatWebView.Dispose ();
				SeatWebView = null;
			}

			if (RefreshButton != null) {
				RefreshButton.Dispose ();
				RefreshButton = null;
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
