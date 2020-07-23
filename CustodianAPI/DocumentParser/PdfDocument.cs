using System;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf.Canvas.Parser;
using Pdf = iText.Kernel.Pdf;

namespace CustodianAPI.DocumentParser
{
    public class PdfDocument : Document
    {
        /// <summary>
        /// Reserved for deserialization with BSON mapper.
        /// </summary>
        public PdfDocument()
        {
        }

        public PdfDocument(string filePath) : base(filePath)
        {
            FullTextIndex();
        }

        protected override void Index()
        {
            var startTime = DateTime.Now;
            Console.Write($"Indexing {Name}");

            # region PDF
            var pdfDocument =
                new Pdf.PdfDocument(new Pdf.PdfReader(new FileStream(Location, FileMode.Open, FileAccess.Read)));
            var totalPageNumber = pdfDocument.GetNumberOfPages();

            for (var i = 1; i <= totalPageNumber; i++)
            {
                // parser.ProcessPageContent(pdfDocument.GetPage(i+1));
                // var text = strategy.GetResultantText();
                var text = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i));
                using var wordEnumerator = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).AsEnumerable()
                    .GetEnumerator();
                while (wordEnumerator.MoveNext())
                {
                    var word = wordEnumerator.Current;
                    var processedWord = ExtractWord(word);
                    if (processedWord == null) continue;

                    if (Thumbnail.ContainsKey(processedWord))
                    {
                        Thumbnail[processedWord]++;
                        continue;
                    }

                    Thumbnail.Add(processedWord, 1);
                }

                // parser.Reset();
            }
            #endregion

            System.Console.Write(
                $" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms");

        }
    }
}
