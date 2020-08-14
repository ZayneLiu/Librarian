using CustodianAPI.Utils;
using Xunit;

namespace CustodianAPI.Test.Utils
{
    public class PowerPoint2007Test
    {
        [Fact]
        public void PDFIndexTest()
        {
            //Given
            var pptxPath = SharedTestData.TestDocFolderPath + "test.pptx";
            var pptmPath = SharedTestData.TestDocFolderPath + "test.pptm";

            //When
            var pptx = new PowerPoint2007Document(pptxPath);
            var pptm = new PowerPoint2007Document(pptmPath);

            //Then
            //FIXME: Check for `tx:body` issue
            // Find another test doc?
            Assert.Equal(expected: 1, actual: pptx.Thumbnail["harikala"]);
            Assert.Equal(expected: 44, actual: pptx.Thumbnail["programming"]);
            Assert.Equal(expected: 28, actual: pptx.Thumbnail["paradigm"]);

            Assert.Equal(expected: 1, actual: pptm.Thumbnail["harikala"]);
            Assert.Equal(expected: 28, actual: pptm.Thumbnail["paradigm"]);
            Assert.Equal(expected: 44, actual: pptm.Thumbnail["programming"]);
        }
    }
}