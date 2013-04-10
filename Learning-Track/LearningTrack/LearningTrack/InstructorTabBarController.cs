// This file has been autogenerated from parsing an Objective-C header file added in Xcode.
using MonoTouch.Foundation;
using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;

namespace LearningTrack
{
	public partial class InstructorTabBarController : UITabBarController
	{
		public int chartType;
		public string courseID;
		public SEATINGCHART mySeatingChart;
		public string userID;

		public InstructorTabBarController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Create UIViewController for Seating Chart reference
			InstructorSeatingChartViewController seatingTab = (InstructorSeatingChartViewController)this.ViewControllers[0];
			InstructorGroupStatisticsViewController groupStatisticsTab = (InstructorGroupStatisticsViewController)this.ViewControllers[1];
			InstructorOptionsViewController optionTab = (InstructorOptionsViewController)this.ViewControllers[2];

			// pass values to their appropriate tabs
			seatingTab.chartType = chartType;
			seatingTab.mySeatingChart = mySeatingChart;
			seatingTab.userID = userID;
			seatingTab.courseID = courseID;

			groupStatisticsTab.chartType = chartType;
			groupStatisticsTab.mySeatingChart = mySeatingChart;
			groupStatisticsTab.userID = userID;
			groupStatisticsTab.courseID = courseID;

			optionTab.courseID = courseID;
		}
	}
}
