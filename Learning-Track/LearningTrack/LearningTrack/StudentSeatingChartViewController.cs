// This file has been autogenerated from parsing an Objective-C header file added in Xcode.

using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;

namespace LearningTrack
{
	public partial class StudentSeatingChartViewController : UIViewController
	{
		public int chartType;

		public StudentSeatingChartViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			//Load the first plot, for now
			LoadSeatingChart(chartType);
		}
		
		public void LoadSeatingChart (int chart)
		{
			//link local filename to become a local HTML URL
			string  fileName;
			
			switch (chart) {
			//Remember case-sensitive
			case 0: fileName = "charts/SeatingCharts/morse_student.html"; break;
			case 1: fileName = "charts/SeatingCharts/studio_student.html"; break;
			default: fileName = "charts/SeatingCharts/morse_student.html"; break;
			}
			
			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
			
			//load the appropriate file to the webView
			SeatWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			SeatWebView.ScalesPageToFit = false;
		}
	}
}
