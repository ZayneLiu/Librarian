using Xunit;
namespace CustodianAPI.Test
{
    public class FolderTest
    {
        [Fact]
        public void IndexTest()
        {
            //Given
            var folder = new Folder(SharedTestData.TestDocFolderPath);
            //When
            folder.Index();
            //Then
            Assert.Equal(10, folder.Documents.Count);
        }
    }

}