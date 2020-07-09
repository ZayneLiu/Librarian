using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace Custodian
{
    public class Custodian
    {
        #region Persistent Functionalities

        private static readonly LiteDatabase CustodianDb = new LiteDatabase("custodian.db");
        private readonly ILiteCollection<Folder> _foldersDb = CustodianDb.GetCollection<Folder>("Files");

        #endregion
        public List<Folder> folders;

        public Custodian()
        {
            folders = _foldersDb.FindAll().ToList();
        }

        public bool TakeCareOf(string shelfPath)
        {

            var folder = new Folder(shelfLocation: shelfPath);
            folder.Index();
            folders.Add(folder);

            _foldersDb.Upsert(id: folder.Location, folder);
            var a = _foldersDb.FindAll().ToList();
            //.ForEach((item) => { })) 
            //var a = shelvesDB.FindAll().ToList();

            //Console.WriteLine(a.Count());
            return true;
        }

        void Find(string[] keywords)
        {
            Console.WriteLine();
            // keywords.ToList().ForEach();
        }
    }
}
