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

				// Figure out where the SQLite database will be.
				var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				_pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");

				//create a table to hold a Person object
				/*using (var conn = new SQLite.SQLiteConnection(_pathToDatabase)){
					conn.CreateTable<Person>();
				}*/
				Database myDB = new Database(_pathToDatabase);// Automatically creates table or 'Person' objects

				//Insert a person into a new row in the table
				var johnDoe  = new Person { firstName = "John", lastName = "Doe"};
				var katsutoshiKawakami  = new Person { firstName = "Katsutoshi", lastName = "Kawakami"};
				var dicksonPun  = new Person { firstName = "Dickson", lastName = "Pun"};

				/*using (var database = new SQLite.SQLiteConnection(_pathToDatabase)){
					database.Insert(johnDoe);
					database.Insert(katsutoshiKawakami);
					database.Insert(dicksonPun);
				}*/

				//CLEAR EVERYTHING
				myDB.DeleteAll<Person>();
				//INSERT NEW ENTRIES
				myDB.Insert(johnDoe);
				myDB.Insert(katsutoshiKawakami);
				myDB.Insert(dicksonPun);
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

