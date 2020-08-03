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
            var ppt = new PowerPoint2007Document(SharedTest.TestDocFolderPath + "Functional Programming.pptx");
            //When


            //Then
            Assert.Equal(expected: 1, actual: ppt.Thumbnail["harikala"]);
            // FIXME:Check for `tx:body` issue
            Assert.Equal(expected: 28, actual: ppt.Thumbnail["paradigm"]);
            Assert.Equal(expected: 44, actual: ppt.Thumbnail["programming"]);
        }
    }
}