using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace Librarian.DataModel
{
    public class DirectoryTableDataSource : NSTableViewDataSource
    {


        #region Public Variables
        public List<Directory> Directories = new List<Directory>();
        #endregion

        #region Constructors
        public DirectoryTableDataSource() { }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Directories.Count;
        }
        #endregion
    }
}
