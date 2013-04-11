using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using System.Xml.Serialization;
using System.Xml;
using cdeutsch;
using WebloginConnection;
using Newtonsoft.Json;

namespace LearningTrack
{
	public partial class InstructorOptionsViewController : UIViewController
	{
		public string courseID;

		public InstructorOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			LoadingIndicator.Hidden = true;
			LoadingIndicator.StopAnimating();
			ClearSeatsButton.Enabled = true;
			changeClassButton.Enabled = true;
			myLabel.Text = "";

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

			ClearSeatsButton.TouchUpInside += (sender, e) =>
			{	
				//Start Loading Indicator and change update label
				LoadingIndicator.Hidden = false;
				LoadingIndicator.StartAnimating();
				ClearSeatsButton.Enabled = false;
				changeClassButton.Enabled = false;
				myLabel.Text = "Please wait for seat clearing confirmation...";
				//Call Asynchronous Clear Seats API
				clearSeats();
			};
		}

		public void clearSeats(){
			var mySelectedCourseID = courseID;
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=clearSeats&course="+mySelectedCourseID);
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Error Message", "Could not get clear seats.", null, "OK", null)){
						LoadingIndicator.Hidden = true;
						LoadingIndicator.StopAnimating();
						ClearSeatsButton.Enabled = true;
						changeClassButton.Enabled = true;
						myLabel.Text = "";
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful RESPONSE PARSE DATA
					SEAT_SELECTION_RESPONSE seatSelectResponse = JsonConvert.DeserializeObject<SEAT_SELECTION_RESPONSE>(data.ToString());
					
					/* Update UI on main thread */
					BeginInvokeOnMainThread(delegate {						
						if (seatSelectResponse.success == true){
							//display error alert message
							using (var alert = new UIAlertView("Successful Seating Clear", "Please refresh the seating chart", null, "OK", null)){	
								LoadingIndicator.Hidden = true;
								LoadingIndicator.StopAnimating();
								alert.Show();
							}
							ClearSeatsButton.Enabled = true;
							changeClassButton.Enabled = true;
							myLabel.Text = "";
						}
						else if (seatSelectResponse.success == false){
							//display error alert message
							using (var alert = new UIAlertView("Unsuccessful Seating Clear", "Please try again.", null, "OK", null)){	
								LoadingIndicator.Hidden = true;
								LoadingIndicator.StopAnimating();
								alert.Show();
							}
							ClearSeatsButton.Enabled = true;
							changeClassButton.Enabled = true;
							myLabel.Text = "";
						}
					});
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

	}
}
