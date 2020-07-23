using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustodianAPI
{
    /// <summary>
    /// Corresponding concept to Directory in file system.
    /// </summary>
    public class Folder
    {
        public string Location { get; set; }
        public List<Document> Documents { get; set; }

        public Folder()
        {

        }
        /// <summary>
        /// Instantiate a Shelf instance (A directory).
        /// And perform preliminary indexing against containing documents automatically.
        /// </summary>
        /// <param name="folderLocation">Location of the shelf. (Path of target directory)</param>
        public Folder(string folderLocation)
        {
            this.Location = folderLocation;
            this.Documents =  new List<Document>();
        }

        /// <summary>
        /// Index all files under given directory (files in sub-directories included)
        /// </summary>
        /// <returns>List of all file paths under given directory</returns>
        public void Index()
        {
            // FIXME: Potential performance issue, use EnumerateFiles instead.
            using var filePaths = Directory.GetFiles(path: this.Location,
                    searchPattern: "*",
                    searchOption: SearchOption.AllDirectories)
                .Where((string filename) =>
                {
                    var ext = Path.GetExtension(filename);
                    // iCloud files that are not local .
                    if (Path.GetExtension(filename)
                        .Equals(value: ".iCloud", comparisonType: StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine($"{filename} needs to be downloaded from iCloud!");
                    var allowedExt = new[] {".txt",".doc", ".docx", ".pdf"};
                    //, ".ppt", ".pptx"
                    // extensions to ignore.
                    var exclude = !new[] {".DS_Store"}.Contains(Path.GetFileName(filename));
                    var include = allowedExt.Contains(ext.ToLower());

                    return exclude & include;
                }).GetEnumerator();

            while (filePaths.MoveNext())
            {
                Console.WriteLine();
                var book = DocumentFactory.Create(filePaths.Current);
                //book.PreliminaryIndex();
                Documents.Add(book);
            }

            //.Where((string filename) =>
            //    !filename.EndsWith(".DS_STORE", StringComparison.OrdinalIgnoreCase)
            //)
        }
    }
}
