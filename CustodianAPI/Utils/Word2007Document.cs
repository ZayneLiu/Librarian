using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CustodianAPI.Utils
{
    /// <summary>
    /// .docx files.
    /// </summary>
    public class Word2007Document : Document
    {
        /// <summary>
        /// Reserved for deserialization with BSON mapper.
        /// </summary>
        public Word2007Document() : base()
        {
        }

        public Word2007Document(string filePath) : base(filePath)
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
            Console.Write($"Indexing {Name}");

            #region Indexing Word documents

            // ReadFiles
            using var doc = WordprocessingDocument.Open(path: Location, isEditable: false);
            var body = doc.MainDocumentPart.Document.Body;
            // Get all <w:p> elements.
            using var paragraphParts = body.Descendants<Paragraph>().GetEnumerator();
            while (paragraphParts.MoveNext())
            {
                var currentParagraph = paragraphParts.Current;
                // Find all <w:t> elements inside each <w:p> element.
                var textParts = currentParagraph.Descendants<Text>().AsQueryable();
                var paragraphTemp = from text in textParts
                                    where text.Text != ""
                                    // Last char is number, possibly page number in Table of content. Add a space manually.
                                    select char.IsNumber(text.Text, text.Text.Length - 1) ? " " + text.Text : text.Text;
                var paragraph = string.Concat(paragraphTemp);

                if (new[] { "" }.Contains(paragraph)) continue;
                if (paragraph == null) continue;

                this.AddToIndex(texts: paragraph);
            }
            #endregion

            Console.Write(
                $" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms\n");

            // FIXED: Elements with similar structure show be ignored.

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
