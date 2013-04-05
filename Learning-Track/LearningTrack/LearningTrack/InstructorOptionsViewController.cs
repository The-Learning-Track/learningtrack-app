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

			changeClassButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML FILES will be and CLEAR EVERYTHING
				string seatingChartPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      
				string courseAveragesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");
				string courseGradesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");
				
				try{
					//Creates new file, overwrites old file automatically - seatingChart.xml
					Stream myStream = new FileStream(seatingChartPath, FileMode.Create);
					//Creates new file, overwrites old file automatically - courseAverages.xml
					myStream = new FileStream(courseAveragesPath, FileMode.Create);
					//Creates new file, overwrites old file automatically - courseGrades.xml
					myStream = new FileStream(courseGradesPath, FileMode.Create);
					//Close stream
					myStream.Flush(); 
					myStream.Close();
				}
				catch (IOException IOe){
				}
				// LOGOUT
				this.ParentViewController.DismissViewController(true, null);
			};
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
