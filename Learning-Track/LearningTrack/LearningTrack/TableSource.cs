using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;

namespace LearningTrack
{
	public class TableSource : UITableViewSource {
		protected string[] tableItems;
		string cellIdentifier = "TableCell";
		public TableSource (string[] items)
		{
				tableItems = items;
		}
		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}
		
		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Length;
		}
		
		/// <summary>
		/// Called when a row is touched
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			new UIAlertView("Row Selected"
			                , tableItems[indexPath.Row], null, "OK", null).Show();
			tableView.DeselectRow (indexPath, true);

		}
		
		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			string item = tableItems[indexPath.Row];
			
			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{  cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); }
			
			cell.TextLabel.Text = item;
			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
			
			return cell;
		}

	}

}

