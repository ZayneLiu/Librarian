using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Custodian
{
    /// <summary>
    /// Corresponding concept to Directory in file system.
    /// </summary>
    public class Folder
    {
        public string Location { get; set; }
        public List<Document> Documents { get; set; }

        /// <summary>
        /// Instantiate a Shelf instance (A directory).
        /// And perform preliminary indexing against containing documents automatically.
        /// </summary>
        /// <param name="folderLocation">Location of the shelf. (Path of target directory)</param>
        public Folder(string folderLocation)
        {
            this.Location = folderLocation;
            this.Documents = new List<Document>();
        }

        /// <summary>
        /// Index all files under given directory (files in sub-directories included)
        /// </summary>
        /// <returns>List of all file paths under given directory</returns>
        public void Index()
        {
            using var result = Directory.GetFiles(path: this.Location,
                    searchPattern: "*",
                    searchOption: SearchOption.AllDirectories)
                .Where((string filename) =>
                {
                    var ext = Path.GetExtension(filename);
                    if (Path.GetExtension(filename)
                        .Equals(value: ".iCloud", comparisonType: StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine($"{filename} needs to be downloaded from iCloud!");
                    var exclude = !new[] {".DS_Store"}.Contains(Path.GetFileName(filename));
                    var allowedExt = new[] {".doc", ".docx"};
                    //, ".ppt", ".pptx"
                    var include = allowedExt.Contains(ext.ToLower());
                    //var include = new[] { ".doc", ".ppt" }.Contains(Path.GetExtension(filename));
                    return exclude & include;
                }).GetEnumerator();

            while (result.MoveNext())
            {
                Console.WriteLine();
                var book = new Document(result.Current);
                //book.PreliminaryIndex();
                Documents.Add(book);
            }

            //.Where((string filename) =>
            //    !filename.EndsWith(".DS_STORE", StringComparison.OrdinalIgnoreCase)
            //)
        }
    }
}
