using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using SQLite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace LearningTrack
{
	public class StudentINFO
	{
		//DOES NOT INCLUDE STUDENT GRADES
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[Indexed]
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string studentID { get; set; }
		public string seatLocation { get; set; }
	}

	public class Grade
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		
		[Indexed]
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

	public class Database : SQLiteConnection
	{
		public Database (string path) : base(path)
		{
			//Automatically create a table for 'Student' and 'Grade' objects
			CreateTable<StudentINFO> ();
			CreateTable<Grade> ();
		}

		public void clearDB ()
		{
			DeleteAll<StudentINFO> ();
			DeleteAll<Grade> ();
		}

		public StudentINFO QueryStudent (string lastName)
		{
			//Extract 'Student' object, depending on last name
			return	(from student in Table<StudentINFO> ()
				where student.lastName == lastName
					select student).FirstOrDefault ();
		}

		public IEnumerable<StudentINFO> QueryAllStudents ()
		{
			//Extract IEnumerable to first 'Student' object (to iterate through with foreach)
			return	from student in Table<StudentINFO> ()
				orderby student.ID
					select student;
		}
		
		public IEnumerable<Grade> QueryAllGrades ()
		{
			//Extract IEnumerable to first 'Grade' object (to iterate through with foreach)
			return	from grade in Table<Grade> ()
				orderby grade.ID
					select grade;
		}

		public List<Grade> extractGrade (StudentINFO student, List<Grade> studentGrades)
		{
			//Store extracted grades in list
			List<Grade> extracted = new List<Grade> ();

			//Search and extract by comparing studentIDs
			foreach (var grade in studentGrades) {
				if (student.studentID == grade.studentID){
					extracted.Add(grade);
				}
			}

			//return extracted list of grades pertaining to requested student
			return extracted;
		}

		public List<Student> getCompleteStudentINFO (List<StudentINFO> studentINFO, List<Grade> grades)
		{
			//Combine studentINFO and grades under a SINGLE 'Student' object and make a list of 'Student' objects
			List <Student> complete = new List<Student>();
			foreach (var student in studentINFO) {
				complete.Add(new Student{firstName = student.firstName,
										lastName = student.lastName,
										seatLocation = student.seatLocation,
										studentID = student.studentID,
										grades = extractGrade(student, grades)});
			}

			return complete;
		}
	}
}

