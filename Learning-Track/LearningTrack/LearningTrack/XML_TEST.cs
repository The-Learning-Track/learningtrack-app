using System;
using System.IO;
using System.Drawing;
using System.Data;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace LearningTrack
{
	public class Result
	{
		public string stop_id { get; set; }
		public string transloc_stop_id { get; set; }
		public string stop_name { get; set; }
		public string stop_desc { get; set; }
		public string stop_lat { get; set; }
		public string stop_lon { get; set; }
		public string direction_id { get; set; }
		public List<string> times { get; set; }
	}
	
	public class ResultSet
	{
		public List<Result> Result { get; set; }
	}
	
	public class BU_BUS_STOPS
	{
		public string title { get; set; }
		public string service_id { get; set; }
		public string active_service_id { get; set; }
		public ResultSet ResultSet { get; set; }
		public int totalResultsAvailable { get; set; }
		public int modified { get; set; }
	}
}

