using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Custodian
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            var url = "file:///Users/zayne/Documents/Herts/PG1000/";
            var targetPath = url.Substring(7);

            var custodian = new Custodian();




            //var files = Directory.GetFiles(url.Substring(7));

            //// Exclude system files i.e. `.DS_Store` etc.

            var aaa = DateTime.Now.Millisecond;

            custodian.TakeCareOf(shelfPath: targetPath);


            //var ignoreList = new string[] { ".DS_Store" };
            //var files = Index(dirPath, ref db, ref dirPath);
            //var result = from file in files
            //             where !ignoreList.Contains(file.Substring(file.LastIndexOf("/") + 1))
            //             select file;

            Console.WriteLine($"{DateTime.Now.Millisecond - aaa}ms");

            Console.WriteLine();

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
