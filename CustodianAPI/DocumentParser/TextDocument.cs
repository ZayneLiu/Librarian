using System;
using System.IO;
using System.Linq;

namespace CustodianAPI.DocumentParser
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

            Console.Write($"Indexing {Name}");

            #region txt

            var encoding = new StreamReader(Location, true).CurrentEncoding;
            var lines = File.ReadAllLines(Location, encoding);

            using var linesEnum = lines.AsEnumerable().GetEnumerator();
            while (linesEnum.MoveNext())
            {
                var currentLine = linesEnum.Current;
                if (currentLine == null)
                    break;
                var wordList = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var word in wordList)
                {
                    var processedWord = ExtractWord(word);
                    if (processedWord == null) continue;

                    if (Thumbnail.ContainsKey(processedWord))
                    {
                        Thumbnail[processedWord]++;
                        continue;
                    }

                    Thumbnail.Add(processedWord, 1);
                }
            }

            System.Console.Write($" >==> {Thumbnail.Count} unique words.");
            #endregion
        }
    }
}
