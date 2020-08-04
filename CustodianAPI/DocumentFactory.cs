using System;
using System.IO;
using System.Linq;
using CustodianAPI.Utils;

namespace CustodianAPI
{
    public static class DocumentFactory
    {
        public static string[] AllowedExtentions
        {
            get
            {
                return TextDocExtensions.Concat(WordExtensions)
                                        .Concat(PowerPointExtentions)
                                        .Concat(ExcelExtension)
                                        .Concat(PdfExtensions)
                                        .ToArray();
            }
            set { }
        }
        // Text Document
        public static string[] TextDocExtensions = new[] { ".txt", };
        // MS Word Document
        public static string[] WordExtensions = new[] { ".docx", ".docm" };
        // MS PowerPoint Documents
        public static string[] PowerPointExtentions = new[] { ".pptx", ".pptm" };
        // MS Excel Documents
        public static string[] ExcelExtension = new[] { ".xlsx", ".xlsm" };
        // PDF Document
        public static string[] PdfExtensions = new[] { ".pdf" };
        public static Document Create(string path)
        {
            var ext = Path.GetExtension(path);

            if (TextDocExtensions.Contains(ext))
                return new TextDocument(path);
            else if (WordExtensions.Contains(ext))
                return new Word2007Document(path);
            else if (PowerPointExtentions.Contains(ext))
                return new PowerPoint2007Document(path);
            else if (ExcelExtension.Contains(ext))
                return new Excel2007Document(path);
            else if (PdfExtensions.Contains(ext))
                return new PdfDocument(path);

            return null;
        }
    }
}
