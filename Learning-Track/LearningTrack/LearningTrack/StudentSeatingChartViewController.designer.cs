// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("StudentSeatingChartViewController")]
	partial class StudentSeatingChartViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView SeatWebView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RefreshButton { get; set; }
		
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
		}
	}
}
