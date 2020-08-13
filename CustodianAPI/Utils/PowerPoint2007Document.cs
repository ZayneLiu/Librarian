
using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;

namespace CustodianAPI.Utils
{

    public class PowerPoint2007Document : Document
    {
        public PowerPoint2007Document() : base()
        {
        }
        public PowerPoint2007Document(string filePath) : base(filePath)
        {
            Index();
        }

        protected override void Index()
        {
            var startTime = DateTime.Now;
            Console.Write($"Indexing {Name}");

            // FIXME: change implementation
            // see https://docs.microsoft.com/en-us/office/open-xml/how-to-get-all-the-text-in-all-slides-in-a-presentation
            #region PowerPoint
            var ppt = PresentationDocument.Open(path: Location, isEditable: false);
            // Get all slides in current presentation.
            using var slides = ppt.PresentationPart.SlideParts.GetEnumerator();

            while (slides.MoveNext())
            {
                var slide = slides.Current;
                // Get all Text elements inside current slide
                using var text = slide.Slide.Descendants<TextBody>().GetEnumerator();
                while (text.MoveNext())
                {
                    this.AddToIndex(texts: text.Current.InnerText);
                }
            }
            #endregion

            Console.Write($" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms\n");
        }
    }
}