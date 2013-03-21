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
using System.Threading;
using System.ComponentModel;

namespace LearningTrack
{
	public partial class LearningTrackViewController : UIViewController
	{
		// get values to transfer to next controller
		public bool _isProfessor;
		public string username;
		public ClassList courses;
		//private static AutoResetEvent mySync = new AutoResetEvent(false);
		public bool isAuthenticated = false;

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

			// When LoginButton is clicked, this will happen:
			LoginButton.TouchUpInside += (sender, e) => {
				//Start animating loading indicator
				this.LoginLoadingIndicator.StartAnimating();

				if (isAuthenticated){
					this.PerformSegue("ToPickClass", this);
				}
				else{
					callBUWebLogin();
				}
					/*Console.WriteLine("Waiting on async call");
					(new Thread(ASyncCallCompleted)).Start();
					mySync.WaitOne();
					Console.WriteLine("Waiting Completed");
					Console.Read();*/
				


				/*
				//Should pass on to Blackboard for verification
				if (username == "dicksonp"){
					//flag for privileges later
					_isProfessor = false;
					//if verified, stop animating loading indicator
					this.LoginLoadingIndicator.StopAnimating();
					this.PerformSegue("ToPickClass", this);
				}
				else if (username == "instructor"){
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
				}*/


				// CONNECT TO KATSU ----------------CHECK FOR BOOL FLAG INSTEAD OF TRY---------------------------------------
				/*if ((username.Length != 0) && (password.Length != 0)){
					//flag for privileges later
					_isProfessor = true;

					// http://thelearningtrack.no-ip.org:8080/theLearningTrack/rest/getCourses/dicksonp
					// PARSE JSON 
					var client = new RestClient();
					client.BaseUrl = "http://thelearningtrack.no-ip.org:8080/theLearningTrack/rest/getCourses/";
					//client.Authenticator = new HttpBasicAuthenticator("username", "password");
					
					var request = new RestRequest();
					request.Resource = username;

					if(username=="realpxy") // For Testing Purposes only
						_isProfessor=false;

					// set format to JSON
					request.RequestFormat = DataFormat.Json;
					
					// automatically deserialize result
					// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
					var responseDeserialized = client.Execute<ClassList>(request);
					
					ClassList RESPONSE = responseDeserialized.Data;
					courses = RESPONSE;

					//Check if user exists
					if (courses == null){
						using (var alert = new UIAlertView("Login Error Message", "Cannot connect to server. Please try again.", null, "OK", null)){
							alert.Show();
							this.LoginLoadingIndicator.StopAnimating();
						}
					}
					else if (courses.Registered == true){
						this.PerformSegue("ToPickClass", this);
					}
					else{
						using (var alert = new UIAlertView("Login Error Message", "Incorrect username or password. Please try again.", null, "OK", null)){
							alert.Show();
							this.LoginLoadingIndicator.StopAnimating();
						}
					}
				}
				else{
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Incorrect username or password. Please try again.", null, "OK", null)){
						alert.Show();
						this.LoginLoadingIndicator.StopAnimating();
					}
				}*/

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
			}
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
					//Upon successful authentication
					isAuthenticated = true;
					BeginInvokeOnMainThread (delegate {
						this.LoginButton.SetTitle ("Continue", UIControlState.Normal);
						this.loginLabel.Hidden = false;
					});
					
					//JsonObject json = (JsonObject)JsonObject.Parse(data.ToString());
					//JsonArray stops = (JsonArray)json["ResultSet"]["Result"];
					
					//-------------------------------------------------------------------
					//DUMMY TESTS -- ASSUME 1 to 1 match up EXPECTED RESPONSE CLASS LIST
					List<string> testCourseNames = new List<string> ();
					testCourseNames.Add ("[Lecture Hall]");
					testCourseNames.Add ("[Studio Classroom]");
					List<string> testCourseIDs = new List<string> ();
					testCourseIDs.Add ("[LECTURE ID]");
					testCourseIDs.Add ("[STUDIO ID]");
					courses = new ClassList{username = "dicksonp", courseNames = testCourseNames, courseIDs = testCourseIDs};
					
					this.LoginLoadingIndicator.StopAnimating();	
					
				}
			});
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

