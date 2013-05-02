using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;
using cdeutsch;
using WebloginConnection;
using Newtonsoft.Json;

namespace LearningTrack
{
	public partial class InstructorOneViewController : UIViewController
	{
		public int chartType;
		public SEATINGCHART mySeatingChart;
		public string userID;
		public string courseID;
		public ClassSeats myClassSeats;
		public gradeINFO myGradeINFO;
		public string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		
		public InstructorOneViewController (IntPtr handle) : base (handle)
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			LoadSeatingChart ();
		}
		
		public void LoadSeatingChart ()
		{
			
			//link local filename to become a local HTML URL
			string  fileNameTopLeft = "charts/VsClassAverage.htm";
			string  fileNameTopRight = "charts/AttendanceChart.htm";
			string  fileNameBottomLeft = "charts/gradeChart.htm";
			string  fileNameBottomRight = "charts/gradeDistribution.htm";

			string localHtmlUrlTopLeft = Path.Combine (NSBundle.MainBundle.BundlePath, fileNameTopLeft);
			string localHtmlUrlTopRight = Path.Combine (NSBundle.MainBundle.BundlePath, fileNameTopRight);
			string localHtmlUrlBottomLeft = Path.Combine (NSBundle.MainBundle.BundlePath, fileNameBottomLeft);
			string localHtmlUrlBottomRight = Path.Combine (NSBundle.MainBundle.BundlePath, fileNameBottomRight);

			//load the appropriate file to the webView
			TopLeftWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrlTopLeft, false)));
			TopRightWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrlTopRight, false)));
			BottomLeftWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrlBottomLeft, false)));
			BottomRightWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrlBottomRight, false)));

			TopLeftWebView.ScalesPageToFit = false;
			TopRightWebView.ScalesPageToFit = false;
			BottomLeftWebView.ScalesPageToFit = false;
			BottomRightWebView.ScalesPageToFit = false;
		}
	}
}
