using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;

namespace LearningTrack
{
	public partial class StudentStatisticsViewController : UIViewController
	{
		public StudentStatisticsViewController (IntPtr handle) : base (handle)
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
			
			//Load the student's statistics
			LoadStudentStatistics();
		}
		
		public void LoadStudentStatistics ()
		{
			//link local filename to become a local HTML URL
			string fileName = "ENTER NEW FILENAME HERE"; 
			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
			
			//load the appropriate file to the webView
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			webView.ScalesPageToFit = false;
		}	
		#endregion
		
	}
}
