using System;
using System.IO;
using iText.Kernel.Pdf.Canvas.Parser;
using Pdf = iText.Kernel.Pdf;

namespace CustodianAPI.Utils
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

                this.AddToIndex(texts: text);
                // parser.Reset();
            }
            #endregion

            Console.Write($" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms");
        }
    }
}
