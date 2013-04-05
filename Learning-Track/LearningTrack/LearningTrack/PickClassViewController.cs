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

namespace LearningTrack
{
	public partial class PickClassViewController : UIViewController
	{
		public bool isProfessor;
		public int selectedRow;
		//get list from previous query
		public ClassList myCourses;
		//need to match these up
		public AssignmentINFO myAssignmentINFO;
		public gradeINFO myGradeINFO;

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

				//Check if data is received
				if ((myGradeINFO == null) || (myAssignmentINFO == null)){
					using (var alert = new UIAlertView("Login Error Message", "Cannot connect to server. Please try again.", null, "OK", null)){
						alert.Show();
					}
				}
				else if((myGradeINFO != null) && (myAssignmentINFO != null) && (myGradeINFO.instructor == true))
				{
					this.PerformSegue("ToInstructorInterface", this);
				}
				else if((myGradeINFO != null) && (myAssignmentINFO != null) && (myGradeINFO.instructor == false))
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
			int derp = 0;
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
					if (derp == 0){
						tempSeatLocation = "A1";
						COMPLETEINFO.Add (new Student{firstName = studentList.firstName, lastName = studentList.lastName, studentID = tempStudentID,
							seatLocation = tempSeatLocation, grades = tempGrade});
						derp = 1;
					}
					else{
						tempSeatLocation = "B1";
						COMPLETEINFO.Add (new Student{firstName = studentList.firstName, lastName = studentList.lastName, studentID = tempStudentID,
							seatLocation = tempSeatLocation, grades = tempGrade});
					}

					//COMPLETEINFO.Add (new Student{firstName = studentList.firstName, lastName = studentList.lastName, studentID = tempStudentID,
					//								seatLocation = tempSeatLocation, grades = tempGrade});
				}
			}

			COURSEGRADES studentGrades = new COURSEGRADES {COURSE_GRADES = COMPLETEINFO};
			//Serialize to XML
			studentGrades.serializeToXML();
			
			/*//DUMMY DATA - NEED TO IMPLEMENT STUDENT XML 
			List <Grade> JohnDoeGrades = new List<Grade> ();
			JohnDoeGrades.Add(new Grade {category = "Homework", assignmentName = "HW1", score = 2, totalPoints = 10, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Homework", assignmentName = "HW2", score = 5, totalPoints = 10, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Homework", assignmentName = "HW3", score = 7, totalPoints = 10, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Exam", assignmentName = "Exam1", score = 29, totalPoints = 100, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Exam", assignmentName = "Exam2", score = 55, totalPoints = 100, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Exam", assignmentName = "Exam3", score = 74, totalPoints = 100, studentID = "000"});
			Student JohnDoe = new Student {firstName = "John", lastName = "Doe", studentID = "000", seatLocation = "A1", grades = JohnDoeGrades};
			
			List <Grade> KatsuGrades = new List<Grade> ();
			KatsuGrades.Add(new Grade {category = "Homework", assignmentName = "HW1", score = 8, totalPoints = 10, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Homework", assignmentName = "HW2", score = 3, totalPoints = 10, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Homework", assignmentName = "HW3", score = 0, totalPoints = 10, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Exam", assignmentName = "Exam1", score = 77, totalPoints = 100, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Exam", assignmentName = "Exam2", score = 56, totalPoints = 100, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Exam", assignmentName = "Exam3", score = 3, totalPoints = 100, studentID = "001"});
			Student Katsu = new Student {firstName = "Katsu", lastName = "Kawakami", studentID = "001", seatLocation = "A3", grades = KatsuGrades};
			
			List <Grade> DicksonGrades = new List<Grade> ();
			DicksonGrades.Add(new Grade {category = "Homework", assignmentName = "HW1", score = 9, totalPoints = 10, studentID = "002"});
			DicksonGrades.Add(new Grade {category = "Homework", assignmentName = "HW2", score = 7, totalPoints = 10, studentID = "002"});
			DicksonGrades.Add(new Grade {category = "Homework", assignmentName = "HW3", score = 9, totalPoints = 10, studentID = "002"});
			DicksonGrades.Add(new Grade {category = "Exam", assignmentName = "Exam1", score = 94, totalPoints = 100, studentID = "002"});
			DicksonGrades.Add(new Grade {category = "Exam", assignmentName = "Exam2", score = 70, totalPoints = 100, studentID = "002"});
			DicksonGrades.Add(new Grade {category = "Exam", assignmentName = "Exam3", score = 97, totalPoints = 100, studentID = "002"});
			Student Dickson = new Student {firstName = "Dickson", lastName = "Pun", studentID = "002", seatLocation = "B1", grades = DicksonGrades};
			
			List <Student> COMPLETEINFO = new List<Student> ();
			COMPLETEINFO.Add (JohnDoe);
			COMPLETEINFO.Add (Katsu);
			COMPLETEINFO.Add (Dickson);
			
			COURSEGRADES studentGrades = new COURSEGRADES {COURSE_GRADES = COMPLETEINFO};
			//Serialize to XML
			studentGrades.serializeToXML();
			*/

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
				//calculate category MAX
				//double categoryMax = function.getMax(MAXs);
				//calculate category MIN
				//double categoryMin = function.getMin(MINs);
				//set values accordingly
				category.categoryAverage = categoryAverage;
				category.categoryStandardDev = categoryStandardDev;
				//category.categoryMax = categoryMax;
				//category.categoryMin = categoryMin;
			}
			//set extracted and calculated values to list of CATEGORY categories to be XML serialized
			STATISTICS statistics = new STATISTICS(){categories = extractedCategories};

			//Create XML for class averages
			statistics.serializeToXML();

			//Assemble XML for Seating Chart
			//Create structure to store XML for seating chart DATA
			List<SEAT> extractedSeating = new List<SEAT>();

			//store list of scores and averages, assume overall weight is even across the category board
			List <double> homeworkScores, examScores, labScores;

			//For each student in list of student get their seating chart data
			foreach (Student student in COMPLETEINFO) {
				SEAT temp = new SEAT();
				temp.SEAT_NUMBER = student.seatLocation;
				temp.NAME = student.firstName;
				temp.STUDENT_ID = student.studentID;
				temp.ATTENDANCE_FLAG = "N/A";
				temp.MISSING_ASSIGNMENT_FLAG = "N/A";
				temp.PREDICT_GRADE = "N/A";
				temp.OVERALL_AVERAGE = "N/A";

				//Get a new list of scores from each student
				homeworkScores = new List<double>();
				examScores = new List<double>();
				labScores = new List<double>();

				//For each grade in list of grades
				foreach (Grade grades in student.grades) {
					//If the assignment and category matches up, add score to the list
					if((grades.category == "Homework")){
						//add score to list to be averaged in assignment
						homeworkScores.Add(grades.score);
					}
					else if((grades.category == "Exam")){
						//add score to list to be averaged in assignment
						examScores.Add(grades.score);
					}
					else if((grades.category == "Lab")){
						//add score to list to be averaged in assignment
						labScores.Add(grades.score);
					}
				}

				if (homeworkScores != null){
					temp.HOMEWORK_AVERAGE = function.getAverage(homeworkScores).ToString();
				}
				else {
					temp.HOMEWORK_AVERAGE = "N/A";
				}

				if (examScores != null){
					temp.EXAM_AVERAGE = function.getAverage(examScores).ToString();
				}
				else {
					temp.EXAM_AVERAGE = "N/A";
				}

				if (labScores != null){
					temp.LAB_AVERAGE = function.getAverage(labScores).ToString();
				}
				else {
					temp.LAB_AVERAGE = "N/A";
				}

				extractedSeating.Add(temp);
			}

			//set extracted and calculated values to list of SEAT seats to be XML serialized
			SEATINGCHART mySeatingChart = new SEATINGCHART (){SEATING_CHART = extractedSeating};
			
			//Create XML for seating chart
			mySeatingChart.serializeToXML();
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
