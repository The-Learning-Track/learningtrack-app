using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using System.Xml.Serialization;
using System.Xml;
namespace LearningTrack
{
	public class STATISTICS
	{
		// Highest level of abstraction
		public List<CATEGORY> categories { get; set; }

		//Method to serialize 'Student' objects to XML
		public void serializeToXML()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<CATEGORY>));
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "courseAverages.xml");      

			//Creates new file, overwrites old file atuomatically
			Stream myStream = new FileStream(path, FileMode.Create);
			
			XmlWriter myXMLWriter = XmlWriter.Create(myStream);
			
			serializer.Serialize(myXMLWriter, categories);   
			
			myStream.Flush(); 
			
			myStream.Close();  
		}
	}

	public class CATEGORY
	{
		public string categoryName { get; set; }

		//standard deviation and average (for the overall category), and list of assignments
		public double categoryStandardDev { get; set; }
		public double categoryAverage { get; set; }
		//public double categoryMax { get; set; }
		//public double categoryMin { get; set; }
		public List <ASSIGNMENT> assignments { get; set; }
	}

	public class ASSIGNMENT
	{
		public string assignmentCategory { get; set; }
		public string assignmentName { get; set; }

		//standard deviation and average
		public double assignmentStandardDev { get; set; }
		public double assignmentAverage { get; set; }
		public double totalPoints { get; set; }
		public double assignmentMax { get; set; }
		public double assignmentMin { get; set; }
	}

	public class CALCULATINGFUNCTIONS
	{
		public double getAverage (List<double> scores)
		{
			double sum = 0;
			double average = 0;

			//Sum total scores
			foreach (double score in scores) {
				sum = sum + score;
			}

			//return average
			average = sum / scores.Count;
			return Math.Round(average,4);
		}

		public double getStandardDev (List<double> scores)
		{
			double sum = 0;
			double average = 0;
			double variance = 0;
			double standardDev = 0;

			//Sum total scores
			foreach (double score in scores) {
				sum = sum + score;
			}

			//get average
			average = sum / scores.Count;

			//get variance
			foreach (double score in scores) {
				variance = variance + Math.Pow((average-score),2);
			}

			//get standard deviation by taking the square root of variance divided by count - 1
			standardDev = Math.Sqrt(variance/(scores.Count - 1));
			return Math.Round(standardDev,4);
		}

		public double getMax (List<double> scores)
		{
			double currentMax = 0;
			bool firstTime = true;

			//check each score
			foreach (double score in scores) {
				if (firstTime){
					//set first score to max
					currentMax = score;
					//set flag to false
					firstTime = false;
				}
				else if (score > currentMax){
					currentMax = score;
				}
			}
			
			//return max
			return Math.Round(currentMax,4);
		}

		public double getMin (List<double> scores)
		{
			double currentMin = 100;
			bool firstTime = true;

			//check each score
			foreach (double score in scores) {
				if (firstTime){
					//set first score to min
					currentMin = score;
					//set flag to false
					firstTime = false;
				}
				else if (score < currentMin){
					currentMin = score;
				}
			}
			
			//return min
			return Math.Round(currentMin,4);
		}
	}
}

