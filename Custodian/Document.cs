using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Custodian
{
    /// <summary>
    /// A object of Document Class contains everything u need to know about a file. path, thumbnail, ful-text index data.
    /// </summary>
    public class Document
    {
        //TODO:Exact type of full-text index data is yet determined.

        public Document(string filename)
        {
            this.Name = filename;
            this.Thumbnail = new Dictionary<string, int>();
            this.IndexData = new Dictionary<string, List<string>>();
            //TODO:Preliminary Index
            //TODO:Full-text index first, preliminary index will be added as a extension.
            FullTextIndex();
        }

        /// <summary>
        /// File path.
        /// </summary>
        public string Name { get; set; }

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
            if (Name is null)
                return;

            Console.WriteLine($"Indexing {Path.GetFileName(Name)} ....");
            //File.ReadLines(Name, encoding: Encoding.UTF8);
            try
            {
                // ReadFiles

                using var doc = WordprocessingDocument.Open(path: Name, isEditable: false);
                var body = doc.MainDocumentPart.Document.Body;

                var words = body.InnerText.Split(' ').GetEnumerator();
                while (words.MoveNext())
                {
                    if (Thumbnail.ContainsKey(words.Current.ToString().ToLower()))
                    {
                        Thumbnail[words.Current.ToString().ToLower()] += 1;
                        continue;
                    }

                    Thumbnail.Add(words.Current.ToString().ToLower(), 1);
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
