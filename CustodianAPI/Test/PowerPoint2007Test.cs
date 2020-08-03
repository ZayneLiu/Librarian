using CustodianAPI.Utils;
using Xunit;

namespace CustodianAPI.Test
{
    public class PowerPoint2007Test
    {
        [Fact]
        public void PDFIndexTest()
        {
            //Given
            var filePath = SharedTestData.TestDocFolderPath + "Functional Programming.pptx";
            //When
            var ppt = new PowerPoint2007Document(filePath);
            //Then
            Assert.Equal(expected: 1, actual: ppt.Thumbnail["harikala"]);
            //FIXME: Check for `tx:body` issue
            Assert.Equal(expected: 28, actual: ppt.Thumbnail["paradigm"]);
            Assert.Equal(expected: 44, actual: ppt.Thumbnail["programming"]);
        }
    }
}