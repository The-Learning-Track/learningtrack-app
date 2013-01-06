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
			
			//Load the first plot, for now
			LoadPlot();
			
			//Populate tableviews for plot selection
			PopulateTableList();
		}
		
		protected void PopulateTableList ()
		{
			//Create list of plots
			List<string> plotList = new List<string> ();
			plotList.Add ("Attendance Chart");
			plotList.Add ("Bar Chart");
			plotList.Add ("Grade Chart");
			
			//Add table items from list
			plotTable.Source = new PlotSelectTableSource (plotList.ToArray(), this);
		}
		
		public void LoadPlot (int plot = 0)
		{
			//link local filename to become a local HTML URL
			string  fileName;
			switch (plot) {
				//Remember case-sensitive
				case 0: fileName = "charts/AttendanceChart.htm"; break;
				case 1: fileName = "charts/barChart.htm"; break;
				case 2: fileName = "charts/gradeChart.htm"; break;
				default: fileName = "charts/AttendanceChart.htm"; break;
			}
			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
			
			//load the appropriate file to the webView
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			webView.ScalesPageToFit = false;
			
		}	
		#endregion
		
	}
}
