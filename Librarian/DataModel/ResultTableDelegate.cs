using System;
using Foundation;
using AppKit;
using System.Collections.Generic;
using Librarian.Models;

namespace Librarian.DataModel
{
    public class ResultTableDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "FileCell";
        #endregion

        #region Private Variables
        private ResultTableDataSource DataSource;
        #endregion

        #region Constructors
        public ResultTableDelegate(ResultTableDataSource datasource)
        {
            this.DataSource = datasource;
        }
        #endregion

        #region Override Methods
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is returned, you modify it enough to reflect the new data
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
                view.LineBreakMode = NSLineBreakMode.TruncatingTail;

            }

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "Name":
                    view.StringValue = DataSource.Files[(int)row].Name;
                    break;
                case "Similarity":
                    view.StringValue = DataSource.Files[(int)row].Similarity;
                    break;
                case "Path":
                    view.StringValue = DataSource.Files[(int)row].Path;
                    break;
            }

            return view;
        }
        #endregion
    }
}
