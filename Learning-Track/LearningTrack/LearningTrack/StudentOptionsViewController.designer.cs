// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("StudentOptionsViewController")]
	partial class StudentOptionsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton changeClassButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton logoutButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (changeClassButton != null) {
				changeClassButton.Dispose ();
				changeClassButton = null;
			}

			if (logoutButton != null) {
				logoutButton.Dispose ();
				logoutButton = null;
			}
		}
	}
}
