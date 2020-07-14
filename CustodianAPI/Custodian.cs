using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;


namespace CustodianAPI
{
    public class Custodian
    {
        #region Persistent Functionalities

        private static readonly LiteDatabase CustodianDb = new LiteDatabase("./custodian.db");
        private static readonly ILiteCollection<Folder> FoldersDb = CustodianDb.GetCollection<Folder>("Files");

        #endregion

        public List<Folder> Folders;

        public Custodian()
        {
            Folders = FoldersDb.FindAll().ToList();
        }

        public Folder TakeCareOf(string shelfPath)
        {
            var folder = new Folder(folderLocation: shelfPath);
            folder.Index();
            Folders.Add(folder);

            FoldersDb.Upsert(id: folder.Location, folder);
            var a = FoldersDb.FindAll().ToList();
            //.ForEach((item) => { })) 
            //var a = shelvesDB.FindAll().ToList();

            //Console.WriteLine(a.Count());
            return folder;
        }

        public List<Document> Search(string[] keywords)
        {
            var result = new List<Document>();
            using var folders = Folders.GetEnumerator();
            try
            {
                while (folders.MoveNext())
                {
                    var current = folders.Current;
                    if (current == null)
                        throw new Exception("no folders indexed.");

                    using var docs = current.Documents.GetEnumerator();
                    while (docs.MoveNext())
                    {
                        var currentDoc = docs.Current;
                        if (currentDoc == null)
                            throw new Exception("no documents indexed.");

                        var intersectResult = currentDoc.Thumbnail.Keys.Intersect(keywords);
                        if (intersectResult.Any())
                        {
                            result.Add(currentDoc);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw;
            }
            finally
            {
                folders.Dispose();
            }


            return result;
        }

        public static void Main(string[] args)
        {
            // var dirnameIndex =
            //     args.ToList().IndexOf(
            //         args.First((s => s.StartsWith("-")))
            //     ) + 1;
            // var dirname = args[dirnameIndex];
            // Console.WriteLine(dirname);

            // var url = "file:///Users/zayne/Documents/Herts/PG1000/";
            // var targetPath = url.Substring(7);
            var targetPath = "/Users/zayne/Workspace/__Data__/Files";

            var custodian = new Custodian();


            //var files = Directory.GetFiles(url.Substring(7));

            //// Exclude system files i.e. `.DS_Store` etc.

            var aaa = DateTime.Now.Millisecond;

            var result = custodian.TakeCareOf(shelfPath: targetPath);


            //var ignoreList = new string[] { ".DS_Store" };
            //var files = Index(dirPath, ref db, ref dirPath);
            //var result = from file in files
            //             where !ignoreList.Contains(file.Substring(file.LastIndexOf("/") + 1))
            //             select file;

            Console.WriteLine(
                System.Text.Json.JsonSerializer.Serialize(result)
            );
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
