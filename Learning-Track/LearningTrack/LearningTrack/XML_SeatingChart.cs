using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using SQLite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace LearningTrack
{
	[Serializable]
	[Preserve]
	/* EXPECTED FORMAT OF XML FILE
	 * -----------------------------
	<SEATING_CHART>
		<SEAT>
	        <SEAT_NUMBER>A1</SEAT_NUMBER>
	        <NAME>Bob</NAME>
	        <OVERALL_AVERAGE>good</OVERALL_AVERAGE>
	        <ATTENDANCE_FLAG>false</ATTENDANCE_FLAG>
	        <MISSING_ASSIGNMENT_FLAG>false</MISSING_ASSIGNMENT_FLAG>
	        <HOMEWORK_AVERAGE>bad</HOMEWORK_AVERAGE>
	        <EXAM_AVERAGE>bad</EXAM_AVERAGE>
	        <LAB_AVERAGE>bad</LAB_AVERAGE>
	        <PREDICT_GRADE>B</PREDICT_GRADE>
		</SEAT>
		<SEAT>
	        <SEAT_NUMBER>A10</SEAT_NUMBER>
	        <NAME>Patrick</NAME>
	        <OVERALL_AVERAGE>bad</OVERALL_AVERAGE>
	        <ATTENDANCE_FLAG>false</ATTENDANCE_FLAG>
	        <MISSING_ASSIGNMENT_FLAG>false</MISSING_ASSIGNMENT_FLAG>
	        <HOMEWORK_AVERAGE>good</HOMEWORK_AVERAGE>
	        <EXAM_AVERAGE>bad</EXAM_AVERAGE>
	        <LAB_AVERAGE>ok</LAB_AVERAGE>
	        <PREDICT_GRADE>B</PREDICT_GRADE>
		</SEAT>
	</SEATING_CHART>
	*/
	public class SEATINGCHART
	{
		//List of 'SEAT' objects
		public List<SEAT> SEATING_CHART{ get; set; }

		//Method to serialize 'SEAT' objects to XML
		public void serializeToXML()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<SEAT>));
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "seatingChart.xml");      

			//Creates new file, overwrites old file atuomatically
			Stream myStream = new FileStream(path, FileMode.Create);
			
			XmlWriter myXMLWriter = XmlWriter.Create(myStream);
			
			serializer.Serialize(myXMLWriter, SEATING_CHART);   
			
			myStream.Flush(); 
			
			myStream.Close();  
		}
	}

   	public class SEAT
	{
		public string SEAT_NUMBER{ get; set; }
		public string NAME{ get; set; }
		public string OVERALL_AVERAGE{ get; set; }
		public string ATTENDANCE_FLAG{ get; set; }
		public string MISSING_ASSIGNMENT_FLAG{ get; set; }
		public string HOMEWORK_AVERAGE{ get; set; }
		public string EXAM_AVERAGE{ get; set; }
		public string LAB_AVERAGE{ get; set; }
		public string PREDICT_GRADE{ get; set; }
	}

	public class COURSEGRADES
	{
		//List of 'Student' objects FOR INDIVIDUAL GRADES
		public List<Student> COURSE_GRADES{ get; set; }
		
		//Method to serialize 'Student' objects to XML
		public void serializeToXML()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseGrades.xml");      
			
			//Creates new file, overwrites old file atuomatically
			Stream myStream = new FileStream(path, FileMode.Create);
			
			XmlWriter myXMLWriter = XmlWriter.Create(myStream);
			
			serializer.Serialize(myXMLWriter, COURSE_GRADES);   
			
			myStream.Flush(); 
			
			myStream.Close();  
		}
	}

}

