// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("InstructorGroupStatisticsViewController")]
	partial class InstructorGroupStatisticsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView webView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RefreshButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView LoadingIndicator { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}

			if (RefreshButton != null) {
				RefreshButton.Dispose ();
				RefreshButton = null;
			}

			if (LoadingIndicator != null) {
				LoadingIndicator.Dispose ();
				LoadingIndicator = null;
			}
		}
	}
}
