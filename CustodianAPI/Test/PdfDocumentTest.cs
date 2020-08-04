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
            // Given
            var filePath = SharedTestData.TestDocFolderPath + "Database System 1.pdf";

            // When
            var testDoc = new PdfDocument(filePath);

            // Then
            Assert.Equal(expected: 9, actual: testDoc.Thumbnail["university"]);
        }
    }
}
