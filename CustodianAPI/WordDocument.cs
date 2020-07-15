using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;

namespace CustodianAPI
{
    public class WordDocument : Document
    {
        /// <summary>
        /// Reserved for deserialization with BSON mapper.
        /// </summary>
        public WordDocument() : base()
        {
        }

        public WordDocument(string filePath) : base(filePath)
        {
            if (filePath == null)
            {
                Console.WriteLine();
            }

            FullTextIndex();
        }

        protected override void Index()
        {
            #region doc / docx

            // ReadFiles
            using var doc = WordprocessingDocument.Open(path: Location, isEditable: false);
            var body = doc.MainDocumentPart.Document.Body;

            using var words = body.InnerText.Split(" ").AsEnumerable().GetEnumerator();
            while (words.MoveNext())
            {
                var currentWord = words.Current;
                if (currentWord == null)
                    throw new Exception();
                var processedWord = ExtractWord(currentWord.ToLower());
                if (processedWord == null) continue;

                if (Thumbnail.ContainsKey(processedWord))
                {
                    Thumbnail[processedWord]++;
                    continue;
                }

                Thumbnail.Add(processedWord, 1);
            }

            #endregion
        }
    }
}
