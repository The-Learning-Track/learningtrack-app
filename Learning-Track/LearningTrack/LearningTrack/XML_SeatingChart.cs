using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace LearningTrack
{
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
		public string STUDENT_ID{ get; set; }
		//public string IS_CURRENT_STUDENT { get; set;}
		//----------------------------------------------------------
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

