using System;
using System.IO;
using System.Linq;

namespace CustodianAPI.Utils
{
    public class TextDocument : Document
    {
        /// <summary>
        /// Reserved for deserialization with BSON mapper.
        /// </summary>
        public TextDocument() : base()
        {
        }

        public TextDocument(string filePath) : base(filePath)
        {
            // Index();
            FullTextIndex();
        }

        protected override void Index()
        {
            if (Location is null)
                return;

            var startTime = DateTime.Now;
            Console.Write($"Indexing {Name}");

            #region txt
            // Get encoding of current document.
            var encoding = new StreamReader(Location, true).CurrentEncoding;
            // Get all lines in `.txt` file as an Enumerator.
            using var lines = File.ReadAllLines(Location, encoding).AsEnumerable().GetEnumerator();

            while (lines.MoveNext())
            {
                var currentLine = lines.Current;
                if (currentLine == null) break;

                this.AddToIndex(texts: currentLine);
            }
            #endregion

            Console.Write($" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms\n");
        }
    }
}
