using Xunit;

namespace CustodianAPI.Test
{
    public class CustodianTest
    {
        [Fact]
        public void IndexTest()
        {
            // Given
            var folderPath = SharedTestData.TestDocFolderPath;
            var custodian = new Custodian();

            // When
            custodian.Reset();
            var result = custodian.TakeCareOf(folderPath: folderPath);

            // Then
            Assert.Equal(10, result.Documents.Count);
        }
        [Fact]
        public void SearchTest()
        {
            //Given
            var keywords = new string[] { "university" };
            var folderPath = SharedTestData.TestDocFolderPath;
            var custodian = new Custodian();

            //When
            custodian.TakeCareOf(folderPath);
            var result = custodian.Search(keywords);
            var resultSize = result.Count;

            //Then
            Assert.Equal(expected: 6, resultSize);
        }

    }
}
