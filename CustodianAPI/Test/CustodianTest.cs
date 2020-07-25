using System;
using Xunit;
using Xunit.Sdk;

namespace CustodianAPI.Test
{
    public class CustodianTest
    {
        [Fact]
        public void Test()
        {
            var targetPath = "/Users/zayne/Workspace/__Data__/Files";

            var custodian = new Custodian();

            // Exclude system files i.e. `.DS_Store` etc.

            var aaa = DateTime.Now;

            var result = custodian.TakeCareOf(shelfPath: targetPath);
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

    }
}
