using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;


namespace CustodianAPI
{
    public class Custodian
    {
        #region Persistence Functionalities
        private static readonly LiteDatabase CustodianDb = new LiteDatabase("./custodian.db");
        private static readonly ILiteCollection<Folder> FoldersDb = CustodianDb.GetCollection<Folder>("Files");
        #endregion

        public static List<Folder> Folders
        {
            get => FoldersDb.FindAll().ToList();
            set { }
        }

        public Custodian()
        {
        }

        public Folder TakeCareOf(string folderPath)
        {
            var folder = new Folder(location: folderPath);
            folder.Index();
            FoldersDb.Upsert(id: folder.Location, folder);
            return folder;
        }
        public void Reset()
        {
            foreach (var collection in CustodianDb.GetCollectionNames())
                CustodianDb.DropCollection(collection);
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

                        // Calculate the intersection of search keywords and index data.
                        var intersection = currentDoc.Thumbnail.Keys.Intersect(keywords);
                        if (intersection.Any())
                        {
                            result.Add(currentDoc);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                folders.Dispose();
            }

            // Preliminary ranking based on the occurrences of search keyword.
            result.Sort((a, b) => b.Thumbnail[keywords[0]].CompareTo(a.Thumbnail[keywords[0]]));
            return result;
        }

    }
}
