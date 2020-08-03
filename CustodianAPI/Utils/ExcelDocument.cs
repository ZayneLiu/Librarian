using System;

namespace CustodianAPI.Utils
{
    public class ExcelDocument : Document
    {
        public ExcelDocument()
        {
        }

        public ExcelDocument(string filePath) : base(filePath)
        {
            Index();
        }


        protected override void Index()
        {
            throw new NotImplementedException();
            // base.Index();

        }
    }
}