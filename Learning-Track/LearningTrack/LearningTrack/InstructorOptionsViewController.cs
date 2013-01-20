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
	public partial class InstructorOptionsViewController : UIViewController
	{
		public InstructorOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		//Store data in a list of 'Person' objects
		public List<Person> listData;
		//Destination directory of database
		private string _pathToDatabase;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			logoutButton.Clicked += (sender, e) => 
			{	
				this.PerformSegue ("InstructorLogout", this);
			};

			// TEST DATABASE
			// Figure out where the SQLite database will be.
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			_pathToDatabase = Path.Combine (documents, "db_sqlite-net.db");

			Database myDB = new Database(_pathToDatabase);// Automatically creates table or 'Person' objects

			//Query from database and recreate list
			List<Person> myPeoples = new List<Person>();
			foreach (var person in myDB.QueryAllStudents()) {
				myPeoples.Add(person);
			}

			int derp = 0;
		}		
	}
}
