using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LearningTrack
{
	public partial class StudentOptionsViewController : UIViewController
	{
		public StudentOptionsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			logoutButton.Clicked += (sender, e) => 
			{	
				this.PerformSegue("StudentLogout", this);
			};
		}
	}
}
