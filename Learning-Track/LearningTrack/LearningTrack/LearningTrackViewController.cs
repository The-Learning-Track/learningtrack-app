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
using RestSharp.Deserializers;

namespace LearningTrack
{
	public partial class LearningTrackViewController : UIViewController
	{
		// get values to transfer to next controller
		public bool _isProfessor;
		public string username;
		public ClassList courses;

		private string _pathToDatabase;

		public LearningTrackViewController (IntPtr handle) : base (handle)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
		
		#region View lifecycle
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Hide Keyboard after textfield entry
			UsernameField.ShouldReturn = delegate{
				UsernameField.ResignFirstResponder();
				return true;
			};
			PasswordField.ShouldReturn = delegate{
				PasswordField.ResignFirstResponder();
				return true;
			};

			// When LoginButton is clicked, this will happen:
			LoginButton.TouchUpInside += (sender, e) => {
				this.LoginLoadingIndicator.StopAnimating();
				//Start animating loading indicator
				this.LoginLoadingIndicator.StartAnimating();

				//Get Username and Password
				username = UsernameField.Text;
				var password = PasswordField.Text;

				//DUMMY TESTS -- ASSUME 1 to 1 match up
				List<string> testCourseNames = new List<string> ();
				testCourseNames.Add ("[Lecture Hall]");
				testCourseNames.Add ("[Studio Classroom]");
				List<string> testCourseIDs = new List<string> ();
				testCourseIDs.Add ("[LECTURE ID]");
				testCourseIDs.Add ("[STUDIO ID]");
				courses = new ClassList{username = "dicksonp", courseNames = testCourseNames, courseIDs = testCourseIDs};

				//Should pass on to Blackboard for verification
				if ((username == "student") && (username.Length != 0) && (password.Length != 0)){
					//flag for privileges later
					_isProfessor = false;
					//if verified, stop animating loading indicator
					this.LoginLoadingIndicator.StopAnimating();
					this.PerformSegue("ToPickClass", this);
				}
				else if ((username == "instructor") && (username.Length != 0) && (password.Length != 0)){
					//flag for privileges later
					_isProfessor = true;
					//if verified, stop animating loading indicator
					this.LoginLoadingIndicator.StopAnimating();
					this.PerformSegue("ToPickClass", this);
				}
				else{
					//stop animating loading indicator
					this.LoginLoadingIndicator.StopAnimating();
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Incorrect username or password. Please try again.", null, "OK", null)){
						alert.Show();
					}
				}

				/* CONNECT TO KATSU ----------------CHECK FOR BOOL FLAG INSTEAD OF TRY---------------------------------------
				if ((username.Length != 0) && (password.Length != 0)){
					//flag for privileges later
					_isProfessor = true;

					try{
						// http://155.41.48.20:8080/theLearningTrack/rest/getCourses/dicksonp
						// PARSE JSON 
						var client = new RestClient();
						client.BaseUrl = "http://155.41.48.20:8080/theLearningTrack/rest/getCourses";
						//client.Authenticator = new HttpBasicAuthenticator("username", "password");
						
						var request = new RestRequest();
						request.Resource = username;
						// set format to JSON
						request.RequestFormat = DataFormat.Json;
						
						// automatically deserialize result
						// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
						var responseDeserialized = client.Execute<ClassList>(request);
						
						ClassList RESPONSE = responseDeserialized.Data;
						courses = RESPONSE;
					}
					catch(NullReferenceException ex){					
						//display error alert message
						using (var alert = new UIAlertView("Login Error Message", "Incorrect username or password. Please try again.", null, "OK", null)){
							alert.Show();
							this.LoginLoadingIndicator.StopAnimating();
						}
					}

					this.PerformSegue("ToPickClass", this);
				}
				else{
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Incorrect username or password. Please try again.", null, "OK", null)){
						alert.Show();
						this.LoginLoadingIndicator.StopAnimating();
					}
				}
				*/
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "ToPickClass") {
				// Get reference to the destination view controller
				var nextViewController = (PickClassViewController) segue.DestinationViewController;
				//Pass bool _isProfessor to the next view controller
				nextViewController.isProfessor = _isProfessor;
				nextViewController.myCourses = courses;

				this.LoginLoadingIndicator.StopAnimating();
				//---------------------------------------------------------------------------------------
				//http://dl.dropbox.com/u/66448605/JSONexample.json
				// PARSE JSON 
				var client = new RestClient();
				client.BaseUrl = "http://dl.dropbox.com";
				//client.Authenticator = new HttpBasicAuthenticator("username", "password");

				var request = new RestRequest();
				request.Resource = "u/66448605/JSONexample.json";
				// set format to JSON
				request.RequestFormat = DataFormat.Json;

				// execute the request
				var response = client.Execute(request);
				var content = response.Content; // raw content as string

				// or automatically deserialize result
				// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
				var responseDeserialized = client.Execute<personJSONLIST>(request);


				personJSONLIST TEST = responseDeserialized.Data;
				//List<Student> BBSTUDENTINFO = responseDeserialized.Data;
				int derp = 0;


				//---------------------------------------------------------------------------------------
				// Figure out where the SQLite database will be.
				var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				_pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");

				//GET DB path to test for iOS directory path
				//string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      

				// Automatically creates table of 'Student' and 'Grade' objects
				Database myDB = new Database(_pathToDatabase);

				//CLEAR EVERYTHING
				myDB.clearDB ();

				//INSERT NEW STUDENTS
				myDB.Insert(new StudentINFO { firstName = "John", lastName = "Doe", studentID = "000", seatLocation = "A1"});
				myDB.Insert(new StudentINFO { firstName = "Katsutoshi", lastName = "Kawakami", studentID = "001", seatLocation = "A3"});
				myDB.Insert(new StudentINFO { firstName = "Dickson", lastName = "Pun", studentID = "002", seatLocation = "B1"});
				//INSERT CORRESPONDING GRADES
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW1", score = 2, totalPoints = 10, studentID = "000"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW2", score = 5, totalPoints = 10, studentID = "000"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW3", score = 7, totalPoints = 10, studentID = "000"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW1", score = 7, totalPoints = 10, studentID = "001"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW2", score = 8, totalPoints = 10, studentID = "001"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW3", score = 8, totalPoints = 10, studentID = "001"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW1", score = 9, totalPoints = 10, studentID = "002"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW2", score = 7, totalPoints = 10, studentID = "002"});
				myDB.Insert(new Grade {category = "Homework", assignmentName = "HW3", score = 9, totalPoints = 10, studentID = "002"});
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
		
		#endregion
	}
}

