using System;
using AppKit;
using Foundation;

namespace Librarian.DataModel
{
    public class DirectoryTableDelegate : NSTableViewDelegate
    {
        private DirectoryTableDataSource DataSource;
        public DirectoryTableDelegate(DirectoryTableDataSource dataSource)
        {
            DataSource = dataSource;
        }

        //[Export("tableView:viewForTableColumn:row:")]
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSButton btn = new NSButton();
            btn.SetButtonType(NSButtonType.Switch);
            btn.Title = DataSource.Directories[(int)row].Path;
            btn.State = NSCellStateValue.On;
            //btn.LineBreakMode = NSLineBreakMode.Clipping;
            //TODO:add horizontal scrollbar

            return btn;
        }
    }
}
