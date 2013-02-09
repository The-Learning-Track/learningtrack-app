using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using System.IO;

namespace LearningTrack
{
	public partial class StudentOptionsViewController : UIViewController
	{
		public StudentOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		//Destination directory of database
		private string _pathToDatabase;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			logoutButton.Clicked += (sender, e) => 
			{	
				// Figure out where the SQLite database will be.
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				_pathToDatabase = Path.Combine(path, "db_sqlite-net.db");
				
				// Automatically creates table of 'Student' and 'Grade' objects
				Database accessDB = new Database(_pathToDatabase);
				
				//CLEAR EVERYTHING
				accessDB.clearDB ();
				//---------------------------------------------------------------------------------------
				//Clear THEN logout
				this.PerformSegue("StudentLogout", this);
			};
		}
	}
}
