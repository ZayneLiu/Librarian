using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CustodianAPI.DocumentParser
{
    /// <summary>
    /// .doc files.
    /// </summary>
    public class Word97Document : Document
    {
        /// <summary>
        /// Reserved for deserialization with BSON mapper.
        /// </summary>
        public Word97Document() : base()
        {
        }

        public Word97Document(string filePath) : base(filePath)
        {
            if (filePath == null)
            {
                Console.WriteLine();
            }

            FullTextIndex();
        }

        protected override void Index()
        {
            // TODO: Add .doc file support.
            throw new NotImplementedException();
            // var startTime = DateTime.Now;
            // Console.Write($"Indexing {Name}");

            // #region doc / docx

            // // ReadFiles
            // using var doc = WordprocessingDocument.Open(path: Location, isEditable: false);
            // var body = doc.MainDocumentPart.Document.Body;
            // using var paragraphParts = body.Descendants<Paragraph>().GetEnumerator();
            // var textList = new List<string>();
            // while (paragraphParts.MoveNext())
            // {
            //     var currentParagraph = paragraphParts.Current;
            //     var textParts = currentParagraph.Descendants<Text>().AsQueryable();
            //     var paragraphTemp = from text in textParts
            //                         where text.Text != ""
            //                         // Last char is number, possibly page number in Table of content. Add a space manually.
            //                         select char.IsNumber(text.Text, text.Text.Length - 1) ? " " + text.Text : text.Text;
            //     var paragraph = string.Concat(paragraphTemp);
            //     textList.Add(paragraph);
            // }
            // using var texts = textList.GetEnumerator();
            // while (texts.MoveNext())
            // {
            //     var p = texts.Current;
            //     if (new[] { "" }.Contains(p)) continue;

            //     if (p == null) continue;
            //     var words = p.Split(" ").AsEnumerable().GetEnumerator();
            //     while (words.MoveNext())
            //     {
            //         var processedWord = ExtractWord(words.Current);
            //         if (processedWord == null) continue;

            //         if (Thumbnail.ContainsKey(processedWord))
            //         {
            //             Thumbnail[processedWord]++;
            //             continue;
            //         }

            //         Thumbnail.Add(processedWord, 1);
            //     }
            // }
            // #endregion

            // System.Console.Write(
            //     $" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms");

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
