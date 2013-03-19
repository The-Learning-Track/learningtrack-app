using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace LearningTrack
{
	public partial class StudentOptionsViewController : UIViewController
	{
		public StudentOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		public ClassList myCourses;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			logoutButton.TouchUpInside += (sender, e) => 
			{	
				// Figure out where the XML FILES will be.
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				
				//CLEAR EVERYTHING

				//---------------------------------------------------------------------------------------
				//Clear THEN logout
				this.PerformSegue("StudentLogout", this);
			};

			// if change class is pressed
			changeClassButton.TouchUpInside += (sender, e) =>
			{	
				// Figure out where the XML FILES will be.
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				
				//CLEAR EVERYTHING
		
				//---------------------------------------------------------------------------------------
				//Clear THEN change class
				this.PerformSegue ("StudentChangeClass", this);
			};
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			//Make sure we are dealing with the appropriate segue
			if (segue.Identifier == "StudentChangeClass") {
				// Get reference to the destination view controller
				var nextViewController = (PickClassViewController) segue.DestinationViewController;
				//Pass values to the next view controller
				nextViewController.myCourses = myCourses;
				nextViewController.isProfessor = false;
			}
		}
	}
}
