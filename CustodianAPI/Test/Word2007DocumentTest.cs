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
            var filePath = SharedTestData.TestDocFolderPath + "EazyCyber.docx";
            // When
            var testDocx = new Word2007Document(filePath);
            // Then
            Assert.Equal(6, testDocx.Thumbnail["university"]);
        }
    }
}
