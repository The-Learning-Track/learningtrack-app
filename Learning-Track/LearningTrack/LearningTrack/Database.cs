using System;
using System.IO;
using System.Drawing;
using System.Data;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace LearningTrack
{
	public class StudentINFO
	{
		//DOES NOT INCLUDE STUDENT GRADES
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string studentID { get; set; }
		public string seatLocation { get; set; }
	}

	public class Grade
	{
		public string category { get; set; }
		public string assignmentName { get; set; }
		public int score { get; set; }
		public int totalPoints { get; set; }
		public string studentID { get; set; }
	}

	public class Student
	{
		//COMPLETE STUDENT OBJECT (INCLUDES GRADES)
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string studentID { get; set; }
		public string seatLocation { get; set; }
		public List<Grade> grades { get; set; }
	}
}

