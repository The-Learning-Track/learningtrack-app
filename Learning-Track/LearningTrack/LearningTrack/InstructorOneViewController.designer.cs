// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("InstructorOneViewController")]
	partial class InstructorOneViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIWebView TopLeftWebView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIWebView TopRightWebView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIWebView BottomLeftWebView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIWebView BottomRightWebView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TopLeftWebView != null) {
				TopLeftWebView.Dispose ();
				TopLeftWebView = null;
			}

			if (TopRightWebView != null) {
				TopRightWebView.Dispose ();
				TopRightWebView = null;
			}

			if (BottomLeftWebView != null) {
				BottomLeftWebView.Dispose ();
				BottomLeftWebView = null;
			}

			if (BottomRightWebView != null) {
				BottomRightWebView.Dispose ();
				BottomRightWebView = null;
			}
		}
	}
}
