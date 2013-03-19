using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace LearningTrack
{
	public class personJSONLIST{
		public List <personJSON> PEOPLE { get; set; }
	}

	public class personJSON
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public int age { get; set; }
		public List<ADDRESS> address { get; set; }
	}
	
	public class ADDRESS
	{
		public string streetAddress { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string postalCode { get; set; }
	}
}

