using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;

namespace LearningTrack
{
	public class ClassList
	{
		// JSON ELEMENTS EXPECTED FROM INITIAL LOGIN
		public List<string> courseNames { get; set; }
		public List<string> courseIDs { get; set; }
		public string userID { get; set; }
		public string username { get; set; }
		public bool Registered { get; set; }
	}

	public class gradeINFO
	{
		public List<StudentList> studentList { get; set; }
		public bool instructor { get; set; }
	}

	public class StudentList
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public List<GradeList> gradeList { get; set; }
		public string studentID { get; set; }
		public string username { get; set; }
	}

	public class GradeList
	{
		public string studentID { get; set; }
		public double score { get; set; }
		public string columnID { get; set; }
	}

	public class AssignmentINFO
	{
		public List<CourseINFO> courseInfo { get; set; }
	}

	public class CourseINFO
	{
		public string category { get; set; }
		public string columnId { get; set; }
		public double possiblePoints { get; set; }
		public string assignmentNames { get; set; }
	}

	public class ClassSeats
	{
		public List<string> seatLocation { get; set; }
		public List<string> usernames { get; set;}
	}

	public class SEAT_REFERENCE
	{
		public string studentID { get; set; }
		public string username { get; set; }
		public string seatLocation { get; set; }
	}
}