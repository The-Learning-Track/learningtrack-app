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

namespace LearningTrack
{
	public class ClassList
	{
		// JSON ELEMENTS EXPECTED FROM INITIAL LOGIN
		public List<string> courseNames { get; set; }
		public List<string> courseIDs { get; set; }
		public string username { get; set; }
		//NEED BOOLEAN FLAG FOR USER-EXISTENCE
	}

	public class userINFO
	{
		// SEND JSON ELEMENTS BACK TO BACKEND FOR FURTHER DATA
		public string username { get; set; }
		public string courseID { get; set; }
		public string courseName { get; set; }
	}
}

