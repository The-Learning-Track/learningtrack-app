using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using SQLite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;

namespace LearningTrack
{
	public partial class PickClassViewController : UIViewController
	{
		public bool isProfessor;
		public int selectedRow;
		//get list from previous query
		public ClassList myCourses;

		public PickClassViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			CreateTableItems();

			//Transition to interface depending on user privileges
			ContinueButton.Clicked += (sender, e) => 
			{					

				//--------------------------------------------------------------------------------------------------
				// PARSE JSON 
				var client = new RestClient();
				client.BaseUrl = "";
				//client.Authenticator = new HttpBasicAuthenticator("username", "password");

				var request = new RestRequest();
				request.Resource = "";
				// set format to JSON
				request.RequestFormat = DataFormat.Json;
				var msg = new userINFO {username = myCourses.username, 
										courseID = myCourses.courseIDs[selectedRow], 
										courseName = myCourses.courseNames[selectedRow]};

				//This will result in a single JSON object, that contains the properties on the object passed into the Serialize method.
				request.AddParameter("infoRequest",request.JsonSerializer.Serialize(msg));

				// automatically deserialize result
				// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
				var responseDeserialized = client.Execute<List<personJSON>>(request);

				List<personJSON> TEST = responseDeserialized.Data;
				//List<Student> BBSTUDENTINFO = responseDeserialized.Data;
				int derp = 0;
				//--------------------------------------------------------------------------------------------------
				if(isProfessor)
				{
					this.PerformSegue("ToInstructorInterface", this);
				}
				else
				{
					this.PerformSegue("ToStudentInterface", this);
				}
			};
		}

		protected void CreateTableItems ()
		{
			//Add table items from list to table
			classTable.Source = new PickClassTableSource(myCourses.courseNames.ToArray(), this);
		}

		// selectedRow determines the seating chart to be displayed
		public void setSelectedRow (int row){
			selectedRow = row;	
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "ToInstructorInterface") {
				// Get reference to the destination view controller
				var nextViewController = (InstructorTabBarController) segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.chartType = selectedRow;
				nextViewController.myCOURSES = myCourses;
			}
			else if (segue.Identifier == "ToStudentInterface") {
				// Get reference to the destination view controller
				var nextViewController = (StudentTabBarController) segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.chartType = selectedRow;
				nextViewController.myCOURSES = myCourses;
			}
		}
	}
}
