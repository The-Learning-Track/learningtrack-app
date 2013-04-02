using System;
using System.IO;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using WebloginConnection;

namespace LearningTrack
{
	public partial class InstructorOptionsViewController : UIViewController
	{
		public InstructorOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		public ClassList myCourses;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// if logout is pressed
			logoutButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML will be.
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				
				//CLEAR EVERYTHING

				//---------------------------------------------------------------------------------------
				//Clear THEN logout
				this.PerformSegue ("InstructorLogout", this);
			};

			// if change class is pressed
			changeClassButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML will be.
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

				//CLEAR EVERYTHING

				//---------------------------------------------------------------------------------------
				//Clear THEN change class
				this.PerformSegue ("InstructorChangeClass", this);
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "InstructorChangeClass") {
				// Get reference to the destination view controller
				var nextViewController = (PickClassViewController) segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.myCourses = myCourses;
				nextViewController.isProfessor = true;
			}
			if (segue.Identifier == "InstructorLogout") {
				// Get reference to the destination view controller
				var nextViewController = (LearningTrackViewController) segue.DestinationViewController;
				// CLEAR XMLS * REMEMBER TO DO SO

				// LOGOUT OF BU WEBLOGIN SESSION
				BUWebloginConnection logout;
			}
		}

	}
}
