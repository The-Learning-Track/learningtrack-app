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
	public class Person
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[Indexed]
		public string firstName { get; set; }
		public string lastName { get; set; }
	}

	public class Database : SQLiteConnection
	{
		public Database (string path) : base(path)
		{
			CreateTable<Person> ();
		}

		public Person QueryStudent (string lastName)
		{
			return	(from student in Table<Person> ()
				where student.lastName == lastName
					select student).FirstOrDefault ();
		}

		public IEnumerable<Person> QueryAllStudents ()
		{
			//TableQuery<Person> query = new TableQuery<Person>(new SQLite.SQLiteConnection(_pathToDatabase));

			return	from student in Table<Person> ()
				orderby student.ID
					select student;
		}
		

	}
}

