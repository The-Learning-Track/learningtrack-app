using System;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;
using cdeutsch;
using WebloginConnection;
using Newtonsoft.Json;

namespace LearningTrack
{
	public partial class InstructorSeatingChartViewController : UIViewController
	{
		public int chartType;
		public SEATINGCHART mySeatingChart;
		public string userID;
		public string courseID;
		public ClassSeats myClassSeats;
		public gradeINFO myGradeINFO;

		public InstructorSeatingChartViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			LoadingIndicator.Hidden = true;

			//Load the first plot, for now
			LoadSeatingChart(chartType);

			RefreshButton.TouchUpInside += (sender, e) => {
				LoadingIndicator.Hidden = false;
				LoadingIndicator.StartAnimating();

				//Get all current seats -> Update XML -> Reload Chart
				getAllSeats();
			};
		}

		public void getAllSeats(){
			var mySelectedCourseID = courseID;
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=getSeats&course="+mySelectedCourseID);
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Could not get seat INFO.", null, "OK", null)){
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					myClassSeats = JsonConvert.DeserializeObject<ClassSeats>(data.ToString());
					
					BeginInvokeOnMainThread(delegate {						
						//Update XML;
						updateXMLPart1();
					});
				}
			});
		}
		
		public void updateXMLPart2 ()
		{
			//Assemble XML for Seating Chart
			//Create structure to store XML for seating chart DATA
			List<SEAT> extractedSeating = new List<SEAT>();
			
			//For each student in list of student get their seating chart data
			foreach (StudentList student in myGradeINFO.studentList) {
				SEAT temp = new SEAT();
				temp.NAME = student.firstName;
				temp.STUDENT_ID = student.studentID;
				if (student.studentID == userID){
					//if the student has the same id as the logged in student, flag this user
					temp.IS_CURRENT_STUDENT = "true";
				}
				else {
					//if the student has the same id as the logged in student, flag this user
					temp.IS_CURRENT_STUDENT = "false";
				}
				string[] tempUsername = myClassSeats.usernames.ToArray();
				string[] tempSeatLocation = myClassSeats.seatLocation.ToArray();
				
				for (int ii = 0; ii < tempUsername.Length; ii++){
					if (tempUsername[ii] == student.username){
						temp.SEAT_NUMBER = tempSeatLocation[ii];
						break;
					}
					else{
						temp.SEAT_NUMBER = "null";
					}
				}
				
				
				extractedSeating.Add(temp);
			}
			
			//set extracted and calculated values to list of SEAT seats to be XML serialized
			mySeatingChart = new SEATINGCHART (){SEATING_CHART = extractedSeating};
			
			//Create XML for seating chart
			mySeatingChart.serializeToXML();
			
			//Refresh Page
			LoadingIndicator.StopAnimating();
			LoadingIndicator.Hidden = true;
			LoadSeatingChart(chartType);
		}
		
		public void updateXMLPart1(){
			var mySelectedCourseID = courseID;
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=getGrades&course="+mySelectedCourseID);
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Could not get grade INFO.", null, "OK", null)){
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					myGradeINFO = JsonConvert.DeserializeObject<gradeINFO>(data.ToString());
					
					BeginInvokeOnMainThread(delegate {						
						updateXMLPart2();
					});
				}
			});
		}

		public void LoadSeatingChart (int chart)
		{
			//link local filename to become a local HTML URL
			string  fileName;

			switch (chart) {
			//Remember case-sensitive
			case 0: fileName = "charts/SeatingCharts/morse.html"; break;
			case 1: fileName = "charts/SeatingCharts/studio.html"; break;
			default: fileName = "charts/SeatingCharts/morse.html"; break;
			}

			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);

			//load the appropriate file to the webView
			SeatWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			SeatWebView.ScalesPageToFit = false;
		}
	}
}
