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
	public partial class StudentSeatingChartViewController : UIViewController
	{
		public int chartType;
		public string courseID;
		public ClassSeats myClassSeats;
		public SEATINGCHART mySeatingChart;
		public string userID;
		public gradeINFO myGradeINFO;
		public string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		public StudentSeatingChartViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{	
			base.ViewDidLoad ();
			LoadingIndicator.Hidden = true;
			RefreshButton.Enabled = true;

			//Load the first plot, for now
			LoadSeatingChart(chartType);

			RefreshButton.TouchUpInside += (sender, e) => {
				LoadingIndicator.Hidden = false;
				LoadingIndicator.StartAnimating();
				RefreshButton.Enabled = false;

				//Get all current seats -> Update XML -> Reload Chart
				getAllSeats();
			};

			//Register Listener for Javascript events.
			this.SeatWebView.AddEventListener("seatCheck", delegate(FireEventData arg) {
				BeginInvokeOnMainThread (delegate { 
					//verify selected seat
					var selectedSeat =  arg.Data["selectedSeat"].ToString();

					myLabel.Text = "Logging into seat: " + selectedSeat + ". Please wait for confirmation...";

					LoadingIndicator.Hidden = false;
					LoadingIndicator.StartAnimating();

					sendSeatLocationToBackend(selectedSeat);
				});	
			});
		}

		public void sendSeatLocationToBackend (string seatLocation){
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=setSeats&course="+courseID+"&location="+seatLocation);
			var request = new NSUrlRequest (url);

			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Lost Connection", "Please try again.", null, "OK", null)){	
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					try{
						//Upon successful RESPONSE PARSE DATA
						SEAT_SELECTION_RESPONSE seatSelectResponse = JsonConvert.DeserializeObject<SEAT_SELECTION_RESPONSE>(data.ToString());
						
						/* Update UI on main thread */
						BeginInvokeOnMainThread(delegate {						
							if (seatSelectResponse.success == true){
								//display error alert message
								using (var alert = new UIAlertView("Successful Attendance", "You are seated at: " + seatLocation, null, "OK", null)){	
									alert.Show();
								}
								myLabel.Text = "";
							}
							else if (seatSelectResponse.success == false){
								//display error alert message
								using (var alert = new UIAlertView("Unsuccessful Attendance", "Please try another seat.", null, "OK", null)){	
									alert.Show();
								}
								myLabel.Text = "";
							}
							//GET UPDATE ON ALL SEATS
							//             "<------MAXIMUM----------LENGTH------>"   For label
							myLabel.Text = "Step 1 of 3: Updating seating chart...";
							getAllSeats();
						});
					}
					catch (Exception e){
						LoadingIndicator.StopAnimating();
						LoadingIndicator.Hidden = true;
						//             "<------MAXIMUM----------LENGTH------>"   For label
						myLabel.Text = "Parsing error at step 1. Try again.";
					}
				}
			});
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
						LoadingIndicator.Hidden = true;
						LoadingIndicator.StopAnimating();
						RefreshButton.Enabled = true;
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					try{
						//Upon successful authentication PARSE DATA
						myClassSeats = JsonConvert.DeserializeObject<ClassSeats>(data.ToString());
						
						BeginInvokeOnMainThread(delegate {						
							//Update XML;
							//             "<------MAXIMUM----------LENGTH------>"   For label
							myLabel.Text = "Step 2 of 3: Matching up students...";
							updateXMLPart1();
						});
					}
					catch (Exception e){
						LoadingIndicator.StopAnimating();
						LoadingIndicator.Hidden = true;
						//             "<------MAXIMUM----------LENGTH------>"   For label
						myLabel.Text = "Parsing error at step 2. Try again.";
					}
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

				if (tempUsername.Length > 0){
					//if there students
					for (int ii = 0; ii < tempUsername.Length; ii++){
						if (tempUsername[ii] == student.username){
							temp.SEAT_NUMBER = tempSeatLocation[ii];
							break;
						}
						else{
							temp.SEAT_NUMBER = "null";
						}
					}
				}
				else{
					//if there are no students set to literal "null"
					temp.SEAT_NUMBER = "null";
				}


				extractedSeating.Add(temp);
			}
			
			//set extracted and calculated values to list of SEAT seats to be XML serialized
			mySeatingChart = new SEATINGCHART (){SEATING_CHART = extractedSeating};
			
			//Create XML for seating chart
			mySeatingChart.serializeToXML();

			//Refresh Page
			myLabel.Text = "";
			LoadingIndicator.Hidden = true;
			LoadingIndicator.StopAnimating();
			RefreshButton.Enabled = true;
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
						LoadingIndicator.Hidden = true;
						LoadingIndicator.StopAnimating();
						RefreshButton.Enabled = true;
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					try{
						//Upon successful authentication PARSE DATA
						myGradeINFO = JsonConvert.DeserializeObject<gradeINFO>(data.ToString());
						
						BeginInvokeOnMainThread(delegate {						
							//             "<------MAXIMUM----------LENGTH------>"   For label
							myLabel.Text = "Step 3 of 3: Writing to XML...";
							updateXMLPart2();
						});
					}
					catch (Exception e){
						LoadingIndicator.StopAnimating();
						LoadingIndicator.Hidden = true;
						//             "<------MAXIMUM----------LENGTH------>"   For label
						myLabel.Text = "Parsing error at step 3. Try again.";
					}
				}
			});
		}

		public void LoadSeatingChart (int chart)
		{
			//link local filename to become a local HTML URL
			string  fileName;
			
			switch (chart) {
			//Remember case-sensitive
			case 0: fileName = "charts/SeatingCharts/morse_student.html"; break;
			case 1: fileName = "charts/SeatingCharts/studio_student.html"; break;
			default: fileName = "charts/SeatingCharts/morse_student.html"; break;
			}
			
			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
			
			//load the appropriate file to the webView
			SeatWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			SeatWebView.ScalesPageToFit = false;

			//Send message to loading html file
			this.SeatWebView.FireEvent("sendPathLocation", new {
				path = path,
				Success = true
			});
		}
	}
}
