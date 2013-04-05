using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using WebloginConnection;
using System.Xml.Serialization;
using System.Xml;

namespace LearningTrack
{
	public partial class StudentOptionsViewController : UIViewController
	{
		public StudentOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			changeClassButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML FILES will be and CLEAR EVERYTHING
				string seatingChartPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      
				string courseAveragesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");
				string courseGradesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");
				
				try{
					//Creates new file, overwrites old file automatically - seatingChart.xml
					Stream myStream = new FileStream(seatingChartPath, FileMode.Create);
					//Close stream
					myStream.Flush(); 
					myStream.Close();
					//Creates new file, overwrites old file automatically - courseAverages.xml
					myStream = new FileStream(courseAveragesPath, FileMode.Create);
					//Close stream
					myStream.Flush(); 
					myStream.Close();
					//Creates new file, overwrites old file automatically - courseGrades.xml
					myStream = new FileStream(courseGradesPath, FileMode.Create);
					//Close stream
					myStream.Flush(); 
					myStream.Close();
				}
				catch (IOException IOe){
					var err = IOe.ToString();
					//display error alert message
					using (var alert = new UIAlertView("Exception Caught", err , null, "OK", null)){
						alert.Show();
					}
				}
				// LOGOUT
				this.ParentViewController.DismissViewController(true, null);
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}
		
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
	}
}
