using Xunit;
using CustodianAPI.Utils;

namespace CustodianAPI.Test.Utils
{
    public class TextTest
    {
        [Fact]
        public void IndexTest()
        {
            //Given
            var txt = new TextDocument(SharedTestData.TestDocFolderPath + "test.txt");
            //When

            //Then
            Assert.Equal(30, txt.Thumbnail["castle"]);
        }
    }
}