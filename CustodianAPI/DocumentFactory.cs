using System.IO;
using System.Linq;

namespace CustodianAPI
{
    public static class DocumentFactory
    {
        public static Document Create(string path)
        {
            var ext = Path.GetExtension(path);
            // Text Document
            var textDocExtensions = new[] {".txt",};
            // MS Word Document
            var wordDocExtensions = new[] {".doc",".docx"};

            if (textDocExtensions.Contains(ext))
            {
                return new TextDocument(path);
            }

            if (wordDocExtensions.Contains(ext))
            {
                return new WordDocument(path);
            }

            return null;
        }
    }
}
