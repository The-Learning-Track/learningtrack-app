// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("Student_StatisticsTabController")]
	partial class Student_StatisticsTabController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView webView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField urlTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton backButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton forwardButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton refreshButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}

			if (urlTextField != null) {
				urlTextField.Dispose ();
				urlTextField = null;
			}

			if (backButton != null) {
				backButton.Dispose ();
				backButton = null;
			}

			if (forwardButton != null) {
				forwardButton.Dispose ();
				forwardButton = null;
			}

			if (refreshButton != null) {
				refreshButton.Dispose ();
				refreshButton = null;
			}
		}
	}
}
