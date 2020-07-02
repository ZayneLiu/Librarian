using System;
using System.Collections.Generic;
using System.IO;

namespace Custodian
{
    /// <summary>
    /// A object of Document Class contains everything u need to know about a file. path, thumbnail, ful-text index data.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// File path.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Preliminary index, only include words and count of ocurances. Hence thumbnail.
        /// </summary>
        public Dictionary<string, int> Thumbnail { get; set; }
        /// <summary>
        /// Full-text index, contains each word and poitions of occurances in the document.
        /// </summary>
        public Dictionary<string, List<string>> FullTextIndex { get; set; }
        //TODO:Exact type of full-text index data is yet determined.

        public Document(string filename)
        {
            this.Name = filename;
            this.Thumbnail = new Dictionary<string, int>();
            this.FullTextIndex = new Dictionary<string, List<string>>();
            Index();
        }

        public void Index()
        {
            //TODO:Preliminary Index
            Console.WriteLine($"Indexing {Path.GetFileName(Name)} ....");
        }
    }
}
