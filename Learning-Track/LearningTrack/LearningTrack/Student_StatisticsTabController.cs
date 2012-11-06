// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LearningTrack
{
	public partial class Student_StatisticsTabController : UIViewController
	{
		public Student_StatisticsTabController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			InitButtons();
			InitWebView ();
			InitUrlTextField();
			MakeFirstRequest ();
		}
		
		void MakeFirstRequest ()
		{
			string url = "http://www.yahoo.com";
			urlTextField.Text = url;
			NSUrlRequest req = new NSUrlRequest (new NSUrl (url));
			webView.LoadRequest (req);
		}
		
		void InitUrlTextField ()
		{
			urlTextField.ShouldReturn = (textField) =>
			{
				urlTextField.ResignFirstResponder ();
				string url = urlTextField.Text;
				if (!url.StartsWith ("http://"))
				url = String.Format ("http://{0}", url);
				NSUrl nsurl = new NSUrl (url);
				NSUrlRequest req = new NSUrlRequest (nsurl);
				webView.LoadRequest (req);
				return true;
			};
		}

		void InitWebView ()
		{
			webView.LoadFinished += delegate { urlTextField.Text = webView.Request.Url.AbsoluteString; };
		}

		void InitButtons ()
		{
			backButton.TouchUpInside += delegate { webView.GoBack (); };
			forwardButton.TouchUpInside += delegate { webView.GoForward (); };
			refreshButton.TouchUpInside += delegate { webView.Reload (); };
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}
		
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
		
		#endregion
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations - LANDSCAPE ONLY
			return true;
		}
	}
}
// This file has been autogenerated from parsing an Objective-C header file added in Xcode.
