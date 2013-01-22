using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using System.IO;

namespace LearningTrack
{
	public partial class InstructorOptionsViewController : UIViewController
	{
		public InstructorOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		//Destination directory of database
		private string _pathToDatabase;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			logoutButton.Clicked += (sender, e) => 
			{	
				this.PerformSegue ("InstructorLogout", this);
			};

			// TEST DATABASE
			// Figure out where the SQLite database will be.
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			_pathToDatabase = Path.Combine (documents, "db_sqlite-net.db");

			// Automatically creates table of 'Student' objects
			Database myDB = new Database(_pathToDatabase);

			//Query from database and recreate list of grades
			List<Grade> studentGrades = new List<Grade>();
			foreach (var grade in myDB.QueryAllGrades()) {
				studentGrades.Add(grade);
			}

			//Query from database and recreate list of students
			List<StudentINFO> studentINFO = new List<StudentINFO>();
			foreach (var student in myDB.QueryAllStudents()) {
				studentINFO.Add(student);
			}

			//Extracted and combined grades and studentINFO under a list of 'Student' objects
			List<Student> COMPLETEINFO = myDB.getCompleteStudentINFO(studentINFO, studentGrades);

			//TEST XML
			SEAT dicksonSeat = new SEAT{SEAT_NUMBER = "A1",
								NAME = "Dickson",
								OVERALL_AVERAGE = "good",
								ATTENDANCE_FLAG = "false",
								MISSING_ASSIGNMENT_FLAG = "false",
								HOMEWORK_AVERAGE = "ok",
								EXAM_AVERAGE = "good",
								LAB_AVERAGE = "good",
								PREDICT_GRADE = "A"};

			SEAT katsuSeat = new SEAT{SEAT_NUMBER = "C5",
								NAME = "Katsu",
								OVERALL_AVERAGE = "bad",
								ATTENDANCE_FLAG = "false",
								MISSING_ASSIGNMENT_FLAG = "true",
								HOMEWORK_AVERAGE = "ok",
								EXAM_AVERAGE = "bad",
								LAB_AVERAGE = "bad",
								PREDICT_GRADE = "C"};
			//Add seats to list of seats
			List<SEAT> classSeats = new List<SEAT>();
			classSeats.Add(dicksonSeat);
			classSeats.Add(katsuSeat);
			//Make seatingChart
			SEATINGCHART mySeatingChart = new SEATINGCHART {SEATING_CHART = classSeats};
			//Store seatingChart in COURSE
			//COURSE myCourse = new COURSE {seatingChart = mySeatingChart};
			//Serialize to XML
			mySeatingChart.serializeToXML();
			//myCourse.serializeToXML();
		}	
	}
}
