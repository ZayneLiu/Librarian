using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using AppKit;
using Foundation;
using Librarian.DataModel;
using Librarian.Models;

namespace Librarian
{
    public partial class ViewController : NSViewController
    {

        public ResultTableDataSource DataSource_ResultTable;
        public DirectoryTableDataSource DataSource_DirTable;

        public ViewController(IntPtr handle) : base(handle)
        {
        }
        /// <summary>
        /// Called after the object has been loaded from the nib file. Overriders must call base.AwakeFromNib()
        /// Vue.js created()/mounted() equivelent.
        /// </summary>
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            //TODO:Load Initial Data

            // Create the Table Data Source and populate it
            DataSource_ResultTable = new ResultTableDataSource();
            DataSource_ResultTable.Files.Add(new Result(name: "Xamarin.iOS", similarity: "100%", path: "Allows you to develop native iOS Applications in C#"));
            DataSource_ResultTable.Files.Add(new Result(name: "Xamarin.Android", similarity: "70%", path: "Allows you to develop native Android Applications in C#"));
            //DataSource_FileTable.Files.Add(new Result("Xamarin.Mac", "Allows you to develop Mac native Applications in C#"));

            DataSource_DirTable = new DirectoryTableDataSource();
            //DataSource_DirTable.Directories.Add(new Directory("path/to/dir"));
            //DataSource_DirTable.Directories.Add(new Directory("path/to/dir"));

            // Populate the Table
            ResultTable.DataSource = DataSource_ResultTable;
            ResultTable.Delegate = new ResultTableDelegate(DataSource_ResultTable);

            DirectoryTable.DataSource = DataSource_DirTable;
            DirectoryTable.Delegate = new DirectoryTableDelegate(DataSource_DirTable);

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
        partial void SearchBtnOnClick(AppKit.NSButton sender)
        {
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseDirectories = true;
            dlg.CanChooseFiles = false;

            if (dlg.RunModal() == 1)
            {
                //Console.WriteLine(dlg.DirectoryUrl);
                //DataSource_DirTable.Directories.Add(new Directory("path/to/dir"));
                DataSource_DirTable.Directories.Add(new Directory(dlg.Url.ToString()));
                Console.WriteLine(dlg.Url.ToString());

            }
            //Call this function each time DataSource is updated.
            DirectoryTable.ReloadData();
        }
    }
}
