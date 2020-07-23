using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iText.Forms.Util;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Pdf = iText.Kernel.Pdf;

namespace CustodianAPI
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
            var pdfDocument =
                new Pdf.PdfDocument(new Pdf.PdfReader(new FileStream(Location, FileMode.Open, FileAccess.Read)));
            var totalPageNumber = pdfDocument.GetNumberOfPages();



            for (var i = 1; i <= totalPageNumber; i++)
            {
                // parser.ProcessPageContent(pdfDocument.GetPage(i+1));
                // var text = strategy.GetResultantText();
                var text = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i));
                using var wordEnumerator = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).AsEnumerable().GetEnumerator();
                while (wordEnumerator.MoveNext())
                {
                    var word = wordEnumerator.Current;
                    var processedWord =ExtractWord(word);
                    if (processedWord ==null) continue;

                    if (Thumbnail.ContainsKey(processedWord))
                    {
                        Thumbnail[processedWord]++;
                        continue;
                    }

                    Thumbnail.Add(processedWord, 1);
                }
                // parser.Reset();
            }
        }
    }
}
