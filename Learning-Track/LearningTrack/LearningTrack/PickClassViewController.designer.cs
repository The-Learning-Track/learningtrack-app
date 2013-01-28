// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace LearningTrack
{
	[Register ("PickClassViewController")]
	partial class PickClassViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem ContinueButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView classTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ContinueButton != null) {
				ContinueButton.Dispose ();
				ContinueButton = null;
			}

			if (classTable != null) {
				classTable.Dispose ();
				classTable = null;
			}
		}
	}
}
