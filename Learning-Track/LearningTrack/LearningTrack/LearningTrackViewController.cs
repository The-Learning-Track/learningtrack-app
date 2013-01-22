using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using SQLite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LearningTrack
{
	public partial class LearningTrackViewController : UIViewController
	{
		public bool _isProfessor;

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
				//Start animating loading indicator
				this.LoginLoadingIndicator.StartAnimating();

				//Get Username and Password
				var username = UsernameField.Text;
				var password = PasswordField.Text;

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

				//---------------------------------------------------------------------------------------
				// Figure out where the SQLite database will be.
				var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				_pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");

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

