// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("StudentStatisticsViewController")]
	partial class StudentStatisticsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView webView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem refreshButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem selectPlotButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}

			if (refreshButton != null) {
				refreshButton.Dispose ();
				refreshButton = null;
			}

			if (selectPlotButton != null) {
				selectPlotButton.Dispose ();
				selectPlotButton = null;
			}
		}
	}
}
