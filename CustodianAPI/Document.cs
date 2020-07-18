using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CustodianAPI
{
    /// <summary>
    /// A object of Document Class contains everything u need to know about a file. path, thumbnail, ful-text index data.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Reserved for deserialization with BSON mapper.
        /// </summary>
        public Document()
        {

        }
        //TODO: Exact type of full-text index data is yet determined.
        public Document(string filePath)
        {
            this.Name = Path.GetFileName(filePath);
            this.Thumbnail = new Dictionary<string, int>();
            this.Location = filePath;
            this.Extension = Path.GetExtension(filePath);
            //TODO: Preliminary Index
            //TODO: Full-text index first, preliminary index will be added as a extension.
            // this.IndexData = new Dictionary<string, List<string>>();
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
        /// File extension.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Preliminary index, only include words and count of occurrences. Hence thumbnail.
        /// </summary>
        public Dictionary<string, int> Thumbnail { get; set; }

        /// <summary>
        /// Full-text index, contains each word and positions of occurrences in the document.
        /// </summary>
        public Dictionary<string, List<string>> IndexData { get; set; }

        protected void FullTextIndex()
        {
            Index();
        }

        protected virtual void Index()
        {
        }

        /// <summary>
        /// Extract word from given string, similar to <code>trim()</code>.
        /// Example:
        /// input => "---:#hello-world?/.,"
        /// output => "hello-world"
        /// </summary>
        /// <param name="word">A string containing the word to be extracted.</param>
        /// <returns>Extracted word.</returns>
        protected static string ExtractWord(string word)
        {
            if (word.Length == 1 && !char.IsLetterOrDigit(word[0]))
            {
                // var a = char.GetUnicodeCategory(word[0]);
                // if (char.IsPunctuation(word[0]))
                //     Console.WriteLine(word);
                //TODO: Potential semantic search data.
                // Console.WriteLine(word);
                return null;
            }

            if (word.Length < 1)
            {
                return null;
            }

            var firstChar = ' ';
            try
            {
                firstChar = word.First(char.IsLetterOrDigit);
            }
            catch (InvalidOperationException e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }

            var firstCharIndex = word.IndexOf(firstChar);
            var lastCharIndex = word.LastIndexOf(word.Last(c => char.IsLetterOrDigit(c)));

            var processedWord = word.Substring(firstCharIndex, lastCharIndex - firstCharIndex + 1).ToLower();
            return processedWord;
        }
    }
}
