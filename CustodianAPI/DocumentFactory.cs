using System.IO;
using System.Linq;
using CustodianAPI.DocumentParser;

namespace CustodianAPI
{
    public static class DocumentFactory
    {
        public static Document Create(string path)
        {
            var ext = Path.GetExtension(path);
            // Text Document
            var textDocExtensions = new[] { ".txt", };
            // MS Word Document
            var wordDocExtensions = new[] { ".doc", ".docx" };
            // PDF Document
            var pdfDocExtensions = new[] { ".pdf" };

            if (textDocExtensions.Contains(ext))
            {
                return new TextDocument(path);
            }

            if (wordDocExtensions.Contains(ext))
            {
                if (ext == ".doc")
                    return new Word97Document(path);
                else
                    return new Word07Document(path);
            }

            if (pdfDocExtensions.Contains(ext))
            {
                return new PdfDocument(path);
            }

            return null;
        }
    }
}
