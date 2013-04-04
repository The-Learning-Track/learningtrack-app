using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using WebloginConnection;
using System.Xml.Serialization;
using System.Xml;

namespace LearningTrack
{
	public partial class InstructorOptionsViewController : UIViewController
	{
		public InstructorOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		public ClassList myCourses;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// if logout is pressed
			logoutButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML FILES will be and CLEAR EVERYTHING
				string seatingChartPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      
				string courseAveragesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");
				string courseGradesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");
				
				//Creates new file, overwrites old file automatically - seatingChart.xml
				Stream myStream = new FileStream(seatingChartPath, FileMode.Create);
				XmlWriter myXMLWriter = XmlWriter.Create(myStream);
				//Creates new file, overwrites old file automatically - courseAverages.xml
				myStream = new FileStream(courseAveragesPath, FileMode.Create);
				myXMLWriter = XmlWriter.Create(myStream);
				//Creates new file, overwrites old file automatically - courseGrades.xml
				myStream = new FileStream(courseGradesPath, FileMode.Create);
				myXMLWriter = XmlWriter.Create(myStream);
				//Close stream
				myStream.Flush(); 
				myStream.Close();

				//---------------------------------------------------------------------------------------
				//Clear THEN logout
				this.PerformSegue ("InstructorLogout", this);
			};

			// if change class is pressed
			changeClassButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML FILES will be and CLEAR EVERYTHING
				string seatingChartPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      
				string courseAveragesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");
				string courseGradesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");
				
				//Creates new file, overwrites old file automatically - seatingChart.xml
				Stream myStream = new FileStream(seatingChartPath, FileMode.Create);
				XmlWriter myXMLWriter = XmlWriter.Create(myStream);
				//Creates new file, overwrites old file automatically - courseAverages.xml
				myStream = new FileStream(courseAveragesPath, FileMode.Create);
				myXMLWriter = XmlWriter.Create(myStream);
				//Creates new file, overwrites old file automatically - courseGrades.xml
				myStream = new FileStream(courseGradesPath, FileMode.Create);
				myXMLWriter = XmlWriter.Create(myStream);
				//Close stream
				myStream.Flush(); 
				myStream.Close();

				//---------------------------------------------------------------------------------------
				//Clear THEN change class
				this.PerformSegue ("InstructorChangeClass", this);
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "InstructorChangeClass") {
				// Get reference to the destination view controller
				var nextViewController = (PickClassViewController) segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.myCourses = myCourses;
				nextViewController.isProfessor = true;
			}
			if (segue.Identifier == "InstructorLogout") {
				// Get reference to the destination view controller
				var nextViewController = (LearningTrackViewController) segue.DestinationViewController;
				// CLEAR XMLS * REMEMBER TO DO SO

				// LOGOUT OF BU WEBLOGIN SESSION
				BUWebloginConnection logout;
			}
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

	}
}
