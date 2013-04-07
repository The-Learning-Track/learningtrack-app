using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using System.Linq;
using WebloginConnection;
using Newtonsoft.Json;

namespace LearningTrack
{
	public partial class PickClassViewController : UIViewController
	{
		public bool isProfessor;
		public int selectedRow;
		public string username; //needed for seating chart
		public string userID; //needed for individual student, filter their data only
		//get list from previous query
		public ClassList myCourses;
		//need to match these up
		public AssignmentINFO myAssignmentINFO;
		public gradeINFO myGradeINFO;
		public ClassSeats myClassSeats;
		public List<SEAT_REFERENCE> seatReferences = new List<SEAT_REFERENCE>();

		public PickClassViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			if (classTable.Source == null){
				CreateTableItems();
			}

			//LOGOUT
			LogoutButton.Clicked += (sender, e) =>
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
				BUWebloginConnection.Logout(); // DELETE COOKIES
				this.DismissViewController(true, null);
			};

			//Transition to interface depending on user privileges
			ContinueButton.Clicked += (sender, e) => 
			{					

				//--------------------------------------------------------------------------------------------------
				// PARSE JSON FOR CLASS DATA
				var myUsername = myCourses.username;
				//var myUserID = myCourses.userID;
				var mySelectedCourseID = myCourses.courseIDs[selectedRow];
				//var mySelectedCourseName = myCourses.courseNames[selectedRow];

				/*
				//-------------------------------------------------------------------------------------------------------------------------
				// get each student's scores and if they are instructor for the class
				var client = new RestClient();
				client.BaseUrl = "http://thelearningtrack.no-ip.org:8080/theLearningTrack/rest/getGrades/"+myUsername+"/"+mySelectedCourseID;
				var request = new RestRequest();
				// set format to JSON
				request.RequestFormat = DataFormat.Json;
				
				// automatically deserialize result
				// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
				var responseDeserialized = client.Execute<gradeINFO>(request);
				
				myGradeINFO = responseDeserialized.Data;
				//--------------------------------------------------------------------------------------------------------------------------
				// get all grade total standards and match via columnID
				var client2 = new RestClient();
				client2.BaseUrl = "http://thelearningtrack.no-ip.org:8080/theLearningTrack/rest/getAssignmentInfo/"+mySelectedCourseID;
				var request2 = new RestRequest();
				// set format to JSON
				request2.RequestFormat = DataFormat.Json;
				
				// automatically deserialize result
				// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
				var responseDeserialized2 = client2.Execute<AssignmentINFO>(request2);
				
				myAssignmentINFO = responseDeserialized2.Data;
				//--------------------------------------------------------------------------------------------------------------------------
				// get all grade total standards and match via columnID
				var client3 = new RestClient();
				client3.BaseUrl = "http://thelearningtrack.no-ip.org:8080/theLearningTrack/rest/getSeats/"+mySelectedCourseID;
				var request3 = new RestRequest();
				// set format to JSON
				request3.RequestFormat = DataFormat.Json;
				
				// automatically deserialize result
				// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
				var responseDeserialized3 = client3.Execute<ClassSeats>(request3);
				
				myClassSeats = responseDeserialized3.Data;
				*/

				getGrades();



			};
		}

		public void continueToSegue(){
			//NEED TO TEST CORRECT SPLIT AND REGROUP
			var myClassSeatsUsernames = myClassSeats.usernames.ToArray();
			var myClassSeatLocations = myClassSeats.seatLocation.ToArray();
			
			for (int count = 0; count < myClassSeats.seatLocation.Count; count++){
				SEAT_REFERENCE tempSeatRef = new SEAT_REFERENCE();
				tempSeatRef.username = myClassSeatsUsernames[count];
				tempSeatRef.seatLocation = myClassSeatLocations[count];
				tempSeatRef.studentID = "";
				seatReferences.Add(tempSeatRef);
			}
			
			//--------------------------------------------------------------------------------------------------------------------------
			//Check if data is received
			if ((myGradeINFO == null) || (myAssignmentINFO == null) || (myClassSeats == null)){
				using (var alert = new UIAlertView("Login Error Message", "Cannot connect to server. Please try again.", null, "OK", null)){
					alert.Show();
				}
			}
			else if((myGradeINFO != null) && (myAssignmentINFO != null) && (myClassSeats != null) && (myGradeINFO.instructor == true))
			{
				this.PerformSegue("ToInstructorInterface", this);
			}
			else if((myGradeINFO != null) && (myAssignmentINFO != null) && (myClassSeats != null) && (myGradeINFO.instructor == false))
			{
				this.PerformSegue("ToStudentInterface", this);
			}
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
				var nextViewController = (InstructorTabBarController)segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.chartType = selectedRow;
			} else if (segue.Identifier == "ToStudentInterface") {
				// Get reference to the destination view controller
				var nextViewController = (StudentTabBarController)segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.chartType = selectedRow;
			}

			//Implement COMPLETEINFO EQUIVALENT
			List<Student> COMPLETEINFO = new List<Student> ();
			string tempStudentID = "";
			string tempSeatLocation = "";

			//for each student
			foreach (StudentList studentList in myGradeINFO.studentList){
				List<Grade> tempGrade = new List<Grade>();
				//for each grade associated with that student
				if (studentList.gradeList.Count != 0){
					foreach (GradeList gradeList in studentList.gradeList){
						//check if the assignment matches up and add it appropriately
						foreach (CourseINFO courseINFO in myAssignmentINFO.courseInfo){
							if (courseINFO.columnId == gradeList.columnID){
								tempGrade.Add (new Grade{category = courseINFO.category, assignmentName = courseINFO.assignmentNames,
										score = gradeList.score, totalPoints = courseINFO.possiblePoints, studentID = gradeList.studentID});
								tempStudentID = gradeList.studentID;
							}
						}
					}
					//MATCH UP USERNAMES TO STUDENTID
					foreach (SEAT_REFERENCE seatRef in seatReferences){
						if (seatRef.username == studentList.username){
							seatRef.studentID = studentList.studentID;
						}
					}

					//get seatlocation
					foreach (SEAT_REFERENCE seatRef in seatReferences){
						if (seatRef.username == studentList.username){
							tempSeatLocation = seatRef.seatLocation;
							break;
						}
						else {
							tempSeatLocation = "null";
						}
					}

					//set all info
					COMPLETEINFO.Add (new Student{firstName = studentList.firstName, lastName = studentList.lastName, studentID = tempStudentID,
													seatLocation = tempSeatLocation, grades = tempGrade});
				}
			}

			COURSEGRADES studentGrades = new COURSEGRADES {COURSE_GRADES = COMPLETEINFO};
			//Serialize to XML
			studentGrades.serializeToXML();

			//---------Get and set standard deviations and averages for all categories and associated assignments--------
			//Create STATISTICS structure from List<Student> first
			List<CATEGORY> extractedCategories = new List<CATEGORY>();

			//For each student in list of student
			foreach (Student student in COMPLETEINFO) {
				//For each grade in list of grades
				foreach (Grade grades in student.grades) {
					//Add category to list if it does not contain the category already
					if(!(extractedCategories.Any(cName => cName.categoryName == grades.category))){
						List<ASSIGNMENT> tempAssignment = new List<ASSIGNMENT> ()
							{(new ASSIGNMENT{assignmentName = grades.assignmentName, totalPoints = grades.totalPoints, assignmentCategory = grades.category})};
						extractedCategories.Add(new CATEGORY{categoryName = grades.category, assignments = tempAssignment});
					}
					//else check if the assignment exists in the category yet
					else{
						foreach (CATEGORY category in extractedCategories){
							//if in the same category but does not contain the assignmentName then add it
							if ((category.categoryName == grades.category) && 
							    !(category.assignments.Any(aName => aName.assignmentName == grades.assignmentName))){

								//add new assignment, name and total points associated
								category.assignments.Add(new ASSIGNMENT{assignmentName = grades.assignmentName, totalPoints = grades.totalPoints,
														assignmentCategory = grades.category});
							}
						}
					}
				}
			} 

			//Calculate functions methods here
			CALCULATINGFUNCTIONS function = new CALCULATINGFUNCTIONS ();

			//store list of scores and averages
			List <double> scores, averages, MAXs, MINs;

			//For each category in extractedCategories
			foreach (CATEGORY category in extractedCategories){
				//Get a new list of averages from each assignment
				averages = new List<double>();
				MAXs = new List<double>();
				MINs = new List<double>();

				//For each assignment in that category's assignment list
				foreach (ASSIGNMENT assignment in category.assignments){
					//Get a new list of scores from each student
					scores = new List<double>();

					//For each student in list of student
					foreach (Student student in COMPLETEINFO) {
						//For each grade in list of grades
						foreach (Grade grades in student.grades) {
							//If the assignment and category matches up, add score to the list
							if((grades.category == category.categoryName) && (grades.assignmentName == assignment.assignmentName)){
								//add score to list to be averaged in assignment
								scores.Add(grades.score);
							}
						}
					}
					//calculate assignment average
					double assignmentAverage = function.getAverage(scores);
					//calculate assignment standard deviation
					double assignmentStandardDev = function.getStandardDev(scores);
					//calculate assignment max
					double assignmentMax = function.getMax(scores);
					//calculate assignment min
					double assignmentMin = function.getMin(scores);
					//set values to its respective assignment
					assignment.assignmentAverage = assignmentAverage;
					assignment.assignmentStandardDev = assignmentStandardDev;
					assignment.assignmentMax = assignmentMax;
					assignment.assignmentMin = assignmentMin;
					//add average, max, min to list to be averaged in category
					averages.Add(assignmentAverage);
					MAXs.Add(assignmentMax);
					MINs.Add(assignmentMin);
				}
				//Calculate category stats after calculating all assignment stats

				//calculate category average
				double categoryAverage = function.getAverage(averages);
				//calculate category standard deviation
				double categoryStandardDev = function.getStandardDev(averages);
				//set values accordingly
				category.categoryAverage = categoryAverage;
				category.categoryStandardDev = categoryStandardDev;
			}
			//set extracted and calculated values to list of CATEGORY categories to be XML serialized
			STATISTICS statistics = new STATISTICS(){categories = extractedCategories};

			//Create XML for class averages
			statistics.serializeToXML();

			//Assemble XML for Seating Chart
			//Create structure to store XML for seating chart DATA
			List<SEAT> extractedSeating = new List<SEAT>();

			//For each student in list of student get their seating chart data
			foreach (Student student in COMPLETEINFO) {
				SEAT temp = new SEAT();
				temp.SEAT_NUMBER = student.seatLocation;
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
				extractedSeating.Add(temp);
			}

			//set extracted and calculated values to list of SEAT seats to be XML serialized
			SEATINGCHART mySeatingChart = new SEATINGCHART (){SEATING_CHART = extractedSeating};
			
			//Create XML for seating chart
			mySeatingChart.serializeToXML();
		}

		public void getGrades(){
			var mySelectedCourseID = myCourses.courseIDs[selectedRow];
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=getGrades&course="+mySelectedCourseID);
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Authentication Fail.\nPlease try again.", null, "OK", null)){
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					myGradeINFO = JsonConvert.DeserializeObject<gradeINFO>(data.ToString());

					BeginInvokeOnMainThread(delegate {						
						getCourseInfo();
					});
				}
			});
		}

		public void getCourseInfo(){
			var mySelectedCourseID = myCourses.courseIDs[selectedRow];
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=getAssignmentInfo&course="+mySelectedCourseID);
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Authentication Fail.\nPlease try again.", null, "OK", null)){
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					myAssignmentINFO = JsonConvert.DeserializeObject<AssignmentINFO>(data.ToString());

					BeginInvokeOnMainThread(delegate {						
						getSeats();
					});
				}
			});
		}

		public void getSeats(){
			var mySelectedCourseID = myCourses.courseIDs[selectedRow];
			//BU WEBLOGIN - ASYNCHRONOUS CALL
			var webloginConnection = new BUWebloginConnection ();
			//var url = new NSUrl ("http://www.bu.edu/phpbin/test/protected/stops.json");
			var url = new NSUrl ("http://www-devl.bu.edu/link/bin/uiscgi_the_learning_track_cbr.pl?operation=getSeats&course="+mySelectedCourseID);
			var request = new NSUrlRequest (url);
			
			webloginConnection.SendAsynchronousRequest (request, NSOperationQueue.CurrentQueue, (response, data, error) => {
				if (data == null){
					//display error alert message
					using (var alert = new UIAlertView("Login Error Message", "Authentication Fail.\nPlease try again.", null, "OK", null)){
						alert.Show();
					}
				}
				else if (data.Length > 0) {
					//Upon successful authentication PARSE DATA
					myClassSeats = JsonConvert.DeserializeObject<ClassSeats>(data.ToString());

					BeginInvokeOnMainThread(delegate {						
						continueToSegue();
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
