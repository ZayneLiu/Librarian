using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Custodian
{
    /// <summary>
    /// Corresponding concept to Directory in file system.
    /// </summary>
    public class Shelf
    {
        public string Location { get; set; }
        public List<Document> Documents { get; set; }

        /// <summary>
        /// Instantiate a Shelf instance (A directory).
        /// And perform preliminary indexing against containing documents automatically.
        /// </summary>
        /// <param name="shelfLocation">Location of the shelf. (Path of target directory)</param>
        public Shelf(string shelfLocation)
        {
            this.Location = shelfLocation;
            this.Documents = new List<Document>();
        }

        /// <summary>
        /// Index all files under given directory (files in sub-directories included)
        /// </summary>
        /// <returns>List of all file paths under given directory</returns>
        public void Index()
        {
            var result = Directory.GetFiles(path: this.Location, searchPattern: "*", searchOption: SearchOption.AllDirectories)
                 .Where((string filename) =>
                 {
                     if (Path.GetExtension(filename).Equals(value: ".icloud", comparisonType: StringComparison.OrdinalIgnoreCase))
                         Console.WriteLine($"{filename} needs to be downloaded from iCloud!");
                     return !new[] { ".DS_Store" }.Contains(Path.GetFileName(filename));
                 }).GetEnumerator();

            while (result.MoveNext())
            {
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
