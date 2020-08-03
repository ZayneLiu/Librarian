using System;
using Xunit;
using Xunit.Sdk;

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
            var result = custodian.TakeCareOf(folderPath: folderPath);
            // Then
            Assert.Equal(11, result.Documents.Count);

            //#region Redis
            //// DB Data Model [dirPath]:[fileList]
            //// "/Users/zayne/Documents/Herts/PG1000/" : []
            ////var client = ConnectionMultiplexer.Connect("localhost");
            ////var db = client.GetDatabase();

            //db.KeyDelete(dirPath);

            //for (int i = 0; i < 3; i++)
            //{
            //    db.ListRightPush(dirPath, "aaa");
            //}
            //Console.WriteLine(db.ListRange(dirPath));

            //Console.WriteLine(client.GetDatabase(0));
            //#endregion
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
            //Then
            Assert.Equal(expected: 0, actual: result.Count)
        }

    }
}
