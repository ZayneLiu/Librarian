using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CustodianAPI
{
    /// <summary>
    /// A object of Document Class contains everything u need to know about a file. path, thumbnail, ful-text index data.
    /// </summary>
    public class Document
    {
        //TODO: Exact type of full-text index data is yet determined.

        public Document(string filePath)
        {
            this.Name = Path.GetFileName(filePath) ;
            this.Thumbnail = new Dictionary<string, int>();
            this.Location = filePath;
            //TODO: Preliminary Index
            //TODO: Full-text index first, preliminary index will be added as a extension.
            // this.IndexData = new Dictionary<string, List<string>>();
            FullTextIndex();
        }

        /// <summary>
        /// File name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File path.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Preliminary index, only include words and count of occurrences. Hence thumbnail.
        /// </summary>
        public Dictionary<string, int> Thumbnail { get; set; }

        /// <summary>
        /// Full-text index, contains each word and positions of occurrences in the document.
        /// </summary>
        public Dictionary<string, List<string>> IndexData { get; set; }

        private void FullTextIndex()
        {
            Index();
            //throw new NotImplementedException();
        }

        private void Index()
        {
            if (Location is null)
                return;

            Console.WriteLine($"Indexing {Name} ....");
            try
            {
                // ReadFiles

                using var doc = WordprocessingDocument.Open(path: Location, isEditable: false);
                var body = doc.MainDocumentPart.Document.Body;

                using var words = body.InnerText.Split(" ").AsEnumerable().GetEnumerator();
                while (words.MoveNext())
                {
                    var currentWord = words.Current;
                    if (currentWord == null)
                        throw new Exception();
                    if (Thumbnail.ContainsKey(currentWord.ToLower()))
                    {
                        Thumbnail[currentWord.ToLower()] += 1;
                        continue;
                    }

                    Thumbnail.Add(currentWord.ToLower(), 1);
                }

                //dict.key
                Console.WriteLine(Thumbnail.Count);
                //var a = File.ReadAllLines(Name, Encoding.UTF8);
                //Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // throw ex;
            }
        }
    }
}
