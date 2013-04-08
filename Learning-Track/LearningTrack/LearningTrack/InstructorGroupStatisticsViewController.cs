using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;

namespace LearningTrack
{
	public partial class InstructorGroupStatisticsViewController : UIViewController
	{
		public int chartType;
		public SEATINGCHART mySeatingChart;
		public string userID;

		public InstructorGroupStatisticsViewController (IntPtr handle) : base (handle)
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
			
			//Load the first plot, for now
			LoadGroupingChart(chartType);

			RefreshButton.TouchUpInside += (sender, e) => {
				//Update XML
				
				//Reload Chart
				LoadGroupingChart(chartType);
			};
		}
		
		public void LoadGroupingChart (int chart)
		{
			//link local filename to become a local HTML URL
			string  fileName;
			
			switch (chart) {
				//Remember case-sensitive
				case 0: fileName = "charts/SeatingCharts/morse_group.html"; break;
				case 1: fileName = "charts/SeatingCharts/studio_group.html"; break;
				default: fileName = "charts/SeatingCharts/morse_group.html"; break;
			}
			
			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
			
			//load the appropriate file to the webView
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			webView.ScalesPageToFit = false;
		}
		#endregion
	}
}
