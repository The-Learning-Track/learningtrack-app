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

		public ClassList myCourses;

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			logoutButton.TouchUpInside += (sender, e) => 
			{	
				// Figure out where the XML FILES will be and CLEAR EVERYTHING
				string seatingChartPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      
				string courseAveragesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");
				string courseGradesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");

				//Creates new file, overwrites old file automatically - seatingChart.xml
				Stream myStream = new FileStream(seatingChartPath, FileMode.Create);
				//Creates new file, overwrites old file automatically - courseAverages.xml
				myStream = new FileStream(courseAveragesPath, FileMode.Create);
				//Creates new file, overwrites old file automatically - courseGrades.xml
				myStream = new FileStream(courseGradesPath, FileMode.Create);
				//Close stream
				myStream.Flush(); 
				myStream.Close();

				// LOGOUT
				Logout();

				//---------------------------------------------------------------------------------------
				//Clear THEN logout
				//this.PerformSegue("StudentLogout", this);

			};

			changeClassButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML FILES will be and CLEAR EVERYTHING
				string seatingChartPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      
				string courseAveragesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");
				string courseGradesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");
				
				//Creates new file, overwrites old file automatically - seatingChart.xml
				Stream myStream = new FileStream(seatingChartPath, FileMode.Create);
				//Creates new file, overwrites old file automatically - courseAverages.xml
				myStream = new FileStream(courseAveragesPath, FileMode.Create);
				//Creates new file, overwrites old file automatically - courseGrades.xml
				myStream = new FileStream(courseGradesPath, FileMode.Create);
				//Close stream
				myStream.Flush(); 
				myStream.Close();
		
				//---------------------------------------------------------------------------------------
				//Clear THEN change class
				//this.PerformSegue ("StudentChangeClass", this);
				this.RemoveFromParentViewController();
				//this.DismissViewController(true,null);
				//this.ParentViewController.DismissViewController(true,null);
			};
		}

		public void Logout(){
			// LOGOUT OF BU WEBLOGIN SESSION
			BUWebloginConnection.Logout();

			/* Update UI on main thread */
			//BeginInvokeOnMainThread(delegate {						
			//this.PerformSegue("StudentLogout", this);
			//this.ParentViewController.RemoveFromParentViewController();
			//});

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "StudentChangeClass") {
				// Get reference to the destination view controller
				var nextViewController = (PickClassViewController) segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.myCourses = myCourses;
				nextViewController.isProfessor = false;

				//this.DismissViewController(false,null);
			}
			//if (segue.Identifier == "StudentLogout") {
				// Get reference to the destination view controller
				//var nextViewController = (LearningTrackViewController) segue.DestinationViewController;
			//}
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
