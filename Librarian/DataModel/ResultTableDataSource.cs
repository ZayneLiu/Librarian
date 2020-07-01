using System;
using Foundation;
using AppKit;
using System.Collections.Generic;
using Librarian.Models;

namespace Librarian.DataModel
{
    public class ResultTableDataSource : NSTableViewDataSource
    {
        #region Public Variables
        public List<Result> Files = new List<Result>();
        #endregion

        #region Constructors
        public ResultTableDataSource()
        {
        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Files.Count;
        }
        #endregion
    }
}
