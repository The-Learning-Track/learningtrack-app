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

namespace LearningTrack
{
	public partial class PickClassViewController : UIViewController
	{
		public bool isProfessor;
		public int selectedRow;
		//get list from previous query
		public ClassList myCourses;

		public PickClassViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			CreateTableItems();

			//Transition to interface depending on user privileges
			ContinueButton.Clicked += (sender, e) => 
			{					

				//--------------------------------------------------------------------------------------------------
				// PARSE JSON FOR CLASS DATA
				var client = new RestClient();
				client.BaseUrl = "";


				var request = new RestRequest();
				request.Resource = "";
				// set format to JSON
				request.RequestFormat = DataFormat.Json;
				var msg = new userINFO {username = myCourses.username, 
										courseID = myCourses.courseIDs[selectedRow], 
										courseName = myCourses.courseNames[selectedRow]};

				//This will result in a single JSON object, that contains the properties on the object passed into the Serialize method.
				request.AddParameter("infoRequest",request.JsonSerializer.Serialize(msg));

				// automatically deserialize result
				// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
				var responseDeserialized = client.Execute<List<Student>>(request);

				List<Student> blackboardData = responseDeserialized.Data;

				//Check if data is received
				/*if (blackboardData == null){
					using (var alert = new UIAlertView("Login Error Message", "Cannot connect to server. Please try again.", null, "OK", null)){
						alert.Show();
					}
				}
				else */if(isProfessor)
				{
					this.PerformSegue("ToInstructorInterface", this);
				}
				else
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
				nextViewController.myCOURSES = myCourses;
			} else if (segue.Identifier == "ToStudentInterface") {
				// Get reference to the destination view controller
				var nextViewController = (StudentTabBarController)segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.chartType = selectedRow;
				nextViewController.myCOURSES = myCourses;
			}

			//DUMMY DATA - NEED TO IMPLEMENT STUDENT XML 
			List <Grade> JohnDoeGrades = new List<Grade> ();
			JohnDoeGrades.Add(new Grade {category = "Homework", assignmentName = "HW1", score = 2, totalPoints = 10, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Homework", assignmentName = "HW2", score = 5, totalPoints = 10, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Homework", assignmentName = "HW3", score = 7, totalPoints = 10, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Exam", assignmentName = "Exam1", score = 29, totalPoints = 100, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Exam", assignmentName = "Exam2", score = 55, totalPoints = 100, studentID = "000"});
			JohnDoeGrades.Add(new Grade {category = "Exam", assignmentName = "Exam3", score = 74, totalPoints = 100, studentID = "000"});
			Student JohnDoe = new Student {firstName = "John", lastName = "Doe", studentID = "000", seatLocation = "A1", grades = JohnDoeGrades};

			List <Grade> KatsuGrades = new List<Grade> ();
			KatsuGrades.Add(new Grade {category = "Homework", assignmentName = "HW1", score = 7, totalPoints = 10, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Homework", assignmentName = "HW2", score = 8, totalPoints = 10, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Homework", assignmentName = "HW3", score = 8, totalPoints = 10, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Exam", assignmentName = "Exam1", score = 77, totalPoints = 100, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Exam", assignmentName = "Exam2", score = 86, totalPoints = 100, studentID = "001"});
			KatsuGrades.Add(new Grade {category = "Exam", assignmentName = "Exam3", score = 83, totalPoints = 100, studentID = "001"});
			Student Katsu = new Student {firstName = "Katsutoshi", lastName = "Kawakami", studentID = "001", seatLocation = "A3", grades = KatsuGrades};

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
							{(new ASSIGNMENT{assignmentName = grades.assignmentName, totalPoints = grades.totalPoints})};
						extractedCategories.Add(new CATEGORY{categoryName = grades.category, assignments = tempAssignment});
					}
					//else check if the assignment exists in the category yet
					else{
						foreach (CATEGORY category in extractedCategories){
							//if in the same category but does not contain the assignmentName then add it
							if ((category.categoryName == grades.category) && 
							    !(category.assignments.Any(aName => aName.assignmentName == grades.assignmentName))){

								//add new assignment, name and total points associated
								category.assignments.Add(new ASSIGNMENT{assignmentName = grades.assignmentName, totalPoints = grades.totalPoints});
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
				double categoryMax = function.getMax(MAXs);
				//calculate category MIN
				double categoryMin = function.getMin(MINs);
				//set values accordingly
				category.categoryAverage = categoryAverage;
				category.categoryStandardDev = categoryStandardDev;
				category.categoryMax = categoryMax;
				category.categoryMin = categoryMin;
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
				temp.ID = student.studentID;
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
	}
}
