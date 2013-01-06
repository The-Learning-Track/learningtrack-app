using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;

namespace LearningTrack
{
	public class PlotSelectTableSource : UITableViewSource {
		protected string[] tableItems;
		//Contructor for loading plot in instructor interface
		public InstructorStatisticsViewController viewInstructor { get; set; }
		//Contructor for loading plot in student interface
		public StudentStatisticsViewController viewStudent { get; set; }
		//to access previous selected path
		public NSIndexPath previous { get; set; }
		string cellIdentifier = "PlotSelectTableCell";

		//Constructors
		public PlotSelectTableSource (string[] items, InstructorStatisticsViewController viewC)
		{
			//constructor for instructor interface
			tableItems = items;
			this.viewInstructor = viewC;
			this.viewStudent = null;
			this.previous = null;
		}
		public PlotSelectTableSource (string[] items, StudentStatisticsViewController viewC)
		{
			//constructor for student interface
			tableItems = items;
			this.viewInstructor = null;
			this.viewStudent = viewC;
			this.previous = null;
		}

		/// Called by the TableView to determine how many sections(groups) there are.
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		/// Called by the TableView to determine how many cells to create for that particular section.
		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Length;
		}

		/// Called when a row is touched
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//When you select a row, that row will be highlighted in blue. Set true to deselect the row
			tableView.DeselectRow (indexPath, true);

			//remove the checkmark on previous selection after first selection
			if (this.previous != null) {
				UITableViewCell prevCell = tableView.CellAt (this.previous);
				prevCell.Accessory = UITableViewCellAccessory.None;
			}

			//Select only one row
			UITableViewCell cell = tableView.CellAt (indexPath);
			cell.Accessory = UITableViewCellAccessory.Checkmark;

			//Load Plot and refresh page
			if (viewStudent == null) {
				//If not in student view, load to instructor
				viewInstructor.LoadPlot (indexPath.Row);
			}
			else if (viewInstructor == null) {
				//If not in instructor view, load to student
				viewStudent.LoadPlot (indexPath.Row);
			}

			//Replace current select to become next selection's previous select
			previous = indexPath;
		}

		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			//if there are no cells to reuse, create a new one
			if (cell == null){
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); 

				if (indexPath.Row == 0){
					//Default first table item to be checkmarked
					cell.Accessory = UITableViewCellAccessory.Checkmark;
					//Replace current select to become next selection's previous select
					previous = indexPath;
				}
			}

			string item = tableItems [indexPath.Row];
			cell.TextLabel.Text = item;
			
			return cell;
		}
		
	}
	
}

