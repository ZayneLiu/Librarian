using CustodianAPI.Utils;
using Xunit;

namespace CustodianAPI.Test.Utils
{
    public class Excel2007Test
    {
        [Fact]
        public void ExcelIndexTest()
        {
            //Given
            var xlsmPath = SharedTestData.TestDocFolderPath + "test.xlsm";
            var xlsxPath = SharedTestData.TestDocFolderPath + "test.xlsx";

            //When
            var xlsx = new Excel2007Document(xlsxPath);
            var xlsm = new Excel2007Document(xlsmPath);

            //Then
            Assert.Equal(1, xlsx.Thumbnail["university"]);
            Assert.Equal(3, xlsx.Thumbnail["123"]);

            Assert.Equal(1, xlsm.Thumbnail["university"]);
            Assert.Equal(3, xlsm.Thumbnail["123"]);
        }
    }
}