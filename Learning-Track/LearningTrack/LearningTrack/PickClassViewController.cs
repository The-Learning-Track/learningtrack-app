using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using SQLite;
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
				// PARSE JSON 
				var client = new RestClient();
				client.BaseUrl = "";
				//client.Authenticator = new HttpBasicAuthenticator("username", "password");

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
				//List<Student> BBSTUDENTINFO = responseDeserialized.Data;
				//--------------------------------------------------------------------------------------------------
				if(isProfessor)
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

			// TEST DATABASE
			// Figure out where the SQLite database will be.
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string _pathToDatabase = Path.Combine (documents, "db_sqlite-net.db");
			
			// Automatically creates table of 'Student' objects
			Database myDB = new Database (_pathToDatabase);
			
			//Query from database and recreate list of grades
			List<Grade> studentGrades = new List<Grade> ();
			foreach (var grade in myDB.QueryAllGrades()) {
				studentGrades.Add (grade);
			}
			
			//Query from database and recreate list of students
			List<StudentINFO> studentINFO = new List<StudentINFO> ();
			foreach (var student in myDB.QueryAllStudents()) {
				studentINFO.Add (student);
			}
			
			//Extracted and combined grades and studentINFO under a list of 'Student' objects
			List<Student> COMPLETEINFO = myDB.getCompleteStudentINFO (studentINFO, studentGrades);

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
			List <double> scores, averages;

			//For each category in extractedCategories
			foreach (CATEGORY category in extractedCategories){
				//Get a new list of averages from each assignment
				averages = new List<double>();

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
					//set values to its respective assignment
					assignment.assignmentAverage = assignmentAverage;
					assignment.assignmentStandardDev = assignmentStandardDev;
					//add average to list to be averaged in category
					averages.Add(assignmentAverage);
				}
				//Calculate category stats after calculating all assignment stats

				//calculate assignment average
				double categoryAverage = function.getAverage(averages);
				//calculate assignment standard deviation
				double categoryStandardDev = function.getStandardDev(averages);
				//set values accordingly
				category.categoryAverage = categoryAverage;
				category.categoryStandardDev = categoryStandardDev;
			}
			//set extracted and calculated values to list of CATEGORY categories to be XML serialized
			STATISTICS statistics = new STATISTICS(){categories = extractedCategories};

			//Create XML for class averages
			statistics.serializeToXML();
		}
	}
}
