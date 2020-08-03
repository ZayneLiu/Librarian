using System;
using DocumentFormat.OpenXml.Packaging;

namespace CustodianAPI.Utils
{
    public class Excel2007Document : Document
    {
        public Excel2007Document()
        {
        }

        public Excel2007Document(string filePath) : base(filePath)
        {
            Index();
        }


        protected override void Index()
        {
            var xlsx = SpreadsheetDocument.Open(path: Location, isEditable: false);
            throw new NotImplementedException();
            // base.Index();

        }
    }
}