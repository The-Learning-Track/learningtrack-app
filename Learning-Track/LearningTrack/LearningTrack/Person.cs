using System;
using SQLite;

namespace LearningTrack
{
	public class Person
	{
		
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		
		public string firstName { get; set; }
		
		public string lastName { get; set; }
	}
}

