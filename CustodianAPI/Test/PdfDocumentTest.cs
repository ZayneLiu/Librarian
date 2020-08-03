using System;
using CustodianAPI.Utils;
using Xunit;
using Xunit.Sdk;

namespace CustodianAPI.Test
{
    public class PdfDocumentTest
    {
        [Fact]
        public void IndexTest()
        {
            var testDoc = new PdfDocument("/Users/zayne/Workspace/Desktop/Librarian/CustodianAPI/Test Doc/Database System 1.pdf");

            Assert.Equal(expected: 9, actual: testDoc.Thumbnail["university"]);
        }
    }
}
