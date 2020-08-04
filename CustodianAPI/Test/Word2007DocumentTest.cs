using Xunit;
using System.Reflection;
using CustodianAPI.Utils;

namespace CustodianAPI.Test
{
    public class Word2007DocumentTest
    {
        [Fact]
        public void Word2007IndexTest()
        {
            // Given
            var docxPath = SharedTestData.TestDocFolderPath + "test.docx";
            var docmPath = SharedTestData.TestDocFolderPath + "test.docm";

            // When
            var docx = new Word2007Document(docxPath);
            var docm = new Word2007Document(docmPath);

            // Then
            Assert.Equal(6, docx.Thumbnail["university"]);

            Assert.Equal(6, docm.Thumbnail["university"]);
        }
    }
}
