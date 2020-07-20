using System;
using System.Linq;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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
            // System.Console.Write($"Indexing {Name}");
            // // Unzip
            // const string xmlDocument = "document.xml";
            // var zip = new ZipArchive(new FileStream(Location, FileMode.Open), ZipArchiveMode.Read);
            // var entries = zip.Entries.AsQueryable();
            // var result = from entry in entries
            //              where entry.Name == xmlDocument
            //              select entry;
            // if (result.Count() != 1)
            // {
            //     var exceptionMsg = result.Count() == 0 ? $"No entry named `{xmlDocument}` found." : $"More than one entries named `{xmlDocument}` found.";
            //     throw new Exception(exceptionMsg);
            // }

            // var arch = result.First().Open();
            // var xml = XmlReader.Create(arch);
            // while (xml.Read())
            // {
            //     if (!xml.CanReadValueChunk)
            //         System.Console.WriteLine();
            //     var s = xml.ReadElementContentAsString();
            //     System.Console.WriteLine();
            // }

            // System.Console.WriteLine(arch.GetType());

            // var a = zip.Entries;

            // Get document.xml

            // Read document.xml

            // Ignore hidden stuff

            // Extract words form the document as usual

            #region doc / docx
            // ReadFiles
            using var doc = WordprocessingDocument.Open(path: Location, isEditable: false);
            var body = doc.MainDocumentPart.Document.Body;
            var paragraphParts = body.Descendants<Paragraph>().GetEnumerator();
            var textList = new List<string>();
            while (paragraphParts.MoveNext())
            {
                var currentParagraph = paragraphParts.Current;
                var textParts = currentParagraph.Descendants<Text>().AsQueryable();
                var p_temp = from text in textParts
                             where text.Text != ""
                             select char.IsNumber(text.Text, text.Text.Length - 1) ? " " + text.Text : text.Text;
                var paragraph = string.Concat(p_temp);
                textList.Add(paragraph);
            }
            var texts = textList.GetEnumerator();
            while (texts.MoveNext())
            {
                var p = texts.Current;
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
            #endregion
            System.Console.Write($" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms");

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
