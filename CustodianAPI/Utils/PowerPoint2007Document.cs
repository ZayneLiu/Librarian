
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
namespace CustodianAPI.Utils
{

    public class PowerPoint2007Document : Document
    {
        public PowerPoint2007Document()
        {
        }

        protected override void Index()
        {
            // base.Index();
            // TODO: PPT
            var ppt = PresentationDocument.Open(path: Location, isEditable: false);
            var slides = ppt.PresentationPart.SlideParts.GetEnumerator();

            while (slides.MoveNext())
            {
                var slide = slides.Current;
                // slide
            }
        }
    }
}