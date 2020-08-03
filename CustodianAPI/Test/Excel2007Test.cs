using CustodianAPI.Utils;
using Xunit;

namespace CustodianAPI.Test
{
    public class Excel2007Test
    {
        [Fact]
        public void ExcelIndexTest()
        {
            //Given
            var filePath = SharedTestData.TestDocFolderPath + "test.xlsx";
            //When
            var xlsx = new Excel2007Document(filePath);
            //Then
            Assert.Equal(1, xlsx.Thumbnail["university"]);
            Assert.Equal(3, xlsx.Thumbnail["123"]);
        }
    }
}