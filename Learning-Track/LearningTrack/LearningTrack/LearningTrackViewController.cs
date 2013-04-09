using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
//using RestSharp;
using WebloginConnection;
using System.Threading;
using System.ComponentModel;
using Newtonsoft.Json;

namespace LearningTrack
{
	public partial class LearningTrackViewController : UIViewController
	{
		// get values to transfer to next controller
		public string username; //needed for seating chart
		public string userID; //needed for individual student, filter their data only
		public ClassList courses;

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

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			// When LoginButton is clicked, this will happen:
			LoginButton.TouchUpInside += (sender, e) => {
				//Start animating loading indicator
				this.LoginLoadingIndicator.StartAnimating();

				//BU WEBLOGIN
				callBUWebLogin();
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "ToPickClass") {
				// Get reference to the destination view controller
				var nextViewController = (PickClassViewController) segue.DestinationViewController;

				//Pass values to the next view controller
				nextViewController.myCourses = courses;
				nextViewController.username = courses.username;
				nextViewController.userID = courses.userID;

				this.LoginLoadingIndicator.StopAnimating();
			}
		}

		public void getCourses(){
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=getCourses");
			var request = new NSUrlRequest (url);

			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Authentication Fail.\nPlease try again.", null, "OK", null)){
						this.LoginLoadingIndicator.StopAnimating();	
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					courses = JsonConvert.DeserializeObject<ClassList>(data.ToString());

					/*//-------------------------------------------------------------------
					//DUMMY TESTS -- ASSUME 1 to 1 match up EXPECTED RESPONSE CLASS LIST
					List<string> testCourseNames = new List<string> ();
					testCourseNames.Add ("OFFLINETEST - [Lecture Hall]");
					testCourseNames.Add ("OFFLINETEST - [Studio Classroom]");
					List<string> testCourseIDs = new List<string> ();
					testCourseIDs.Add ("[LECTURE ID]");
					testCourseIDs.Add ("[STUDIO ID]");
					courses = new ClassList{username = "dicksonp", courseNames = testCourseNames, courseIDs = testCourseIDs};
					*/

					this.LoginLoadingIndicator.StopAnimating();	
					/* Update UI on main thread */
					BeginInvokeOnMainThread(delegate {
						myLabel.Text = "";
						this.PerformSegue("ToPickClass", this);
					});
				}
			});
		}

		public void callBUWebLogin(){
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Authentication Fail.\nPlease try again.", null, "OK", null)){
						this.LoginLoadingIndicator.StopAnimating();	
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					//JUST GET AUTHENTICATED COOKIES AT THIS POINT
	
					/* Update UI on main thread */
					BeginInvokeOnMainThread(delegate {						
						myLabel.Text = "Successful Authentication. Now retrieving your courses...";
						getCourses();
					});
				}
			});
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
		
		#endregion
	}
}

