// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Librarian
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableView DirectoryTable { get; set; }

		[Outlet]
		AppKit.NSTableView ResultTable { get; set; }

		[Outlet]
		AppKit.NSTextField SearchBarTextField { get; set; }

		[Action ("SearchbarTextChanged:")]
		partial void SearchbarTextChanged (AppKit.NSTextField sender);

		[Action ("SearchBtnOnClick:")]
		partial void SearchBtnOnClick (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DirectoryTable != null) {
				DirectoryTable.Dispose ();
				DirectoryTable = null;
			}

			if (ResultTable != null) {
				ResultTable.Dispose ();
				ResultTable = null;
			}

			if (SearchBarTextField != null) {
				SearchBarTextField.Dispose ();
				SearchBarTextField = null;
			}
		}
	}
}
