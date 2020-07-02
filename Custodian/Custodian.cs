using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using LiteDB;

namespace Custodian
{
    public class Custodian
    {
        #region Persistent Functionalities
        public static LiteDatabase custodianDB = new LiteDatabase("custodian.db");
        ILiteCollection<Shelf> shelvesDB = custodianDB.GetCollection<Shelf>("Shelves");
        #endregion
        public List<Shelf> shelves = new List<Shelf>();

        public Custodian()
        {
            shelves = shelvesDB.FindAll().ToList();
        }

        public bool TakeCareOf(string shelfPath)
        {

            var shelf = new Shelf(shelfLocation: shelfPath);
            shelf.Index();
            shelves.Add(shelf);


            shelvesDB.Upsert(id: shelf.Location, shelf);
            //var a = shelvesDB.FindAll().ToList();


            Console.WriteLine(a.Count());
            return true;
        }


        //    #region Redis
        //    // DB Data Model [dirPath]:[fileList]
        //    // "/Users/zayne/Documents/Herts/PG1000/" : []


        //    db.KeyDelete(dirPath);

        //        for (int i = 0; i< 3; i++)
        //        {
        //            db.ListRightPush(dirPath, "aaa");
        //        }
        //Console.WriteLine(db.ListRange(dirPath));

        //        Console.WriteLine(client.GetDatabase(0));
        //        #endregion
    }
}
