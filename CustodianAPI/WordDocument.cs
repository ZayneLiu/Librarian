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
            var startTime = DateTime.Now;
            #region doc / docx
            System.Console.Write($"Indexing {Name}");

            // ReadFiles
            using var doc = WordprocessingDocument.Open(path: Location, isEditable: false);
            var body = doc.MainDocumentPart.Document.Body;
            // doc.MainDocumentPart.Document
            // body.ClearAllAttributes();
            var children = body.ChildElements.GetEnumerator();
            while (children.MoveNext())
            {
                var p = children.Current.InnerText;
                if (new[] { "" }.Contains(p)) continue;

                var words = p.Split(" ").AsEnumerable().GetEnumerator();
                while (words.MoveNext())
                {
                    var processedWord = ExtractWord(words.Current);
                    if (processedWord == null) continue;

                    if (Thumbnail.ContainsKey(processedWord))
                    {
                        Thumbnail[processedWord]++;
                        continue;
                    }

                    Thumbnail.Add(processedWord, 1);

                }
            }

            System.Console.Write($" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms");
            #endregion

            // FIXME: Elements with similar structure show be ignored.

            /*
            <w:r>
                <w:rPr>
                    <w:noProof/>
                    <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
            </w:r>
            <w:r>
                <w:rPr>
                    <w:noProof/>
                    <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc26994498 \h </w:instrText>
            </w:r>
            */
        }
    }
}
