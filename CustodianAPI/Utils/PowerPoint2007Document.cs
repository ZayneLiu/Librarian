
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
            //TODO: PPT
            var ppt = PresentationDocument.Open(path: Location, isEditable: false);
            using var slides = ppt.PresentationPart.SlideParts.GetEnumerator();

            while (slides.MoveNext())
            {
                var slide = slides.Current;
                using var text = slide.Slide.Descendants<TextBody>().GetEnumerator();
                while (text.MoveNext())
                {
                    this.AddToIndex(texts: text.Current.InnerText);
                }
            }
        }
    }
}