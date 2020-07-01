using System;
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



            var files = Directory.GetFiles(url.Substring(7));

            //// Exclude system files i.e. `.DS_Store` etc.
            //var ignoreList = new string[] { ".DS_Store" };
            //var result = from file in files
            //             where !ignoreList.Contains(file.Substring(file.LastIndexOf("/") + 1))
            //             select file;

            //Console.WriteLine(result);
            //Console.WriteLine($"{dir.Length} files found.");

            var a = Index(url.Substring(7));
            //Console.WriteLine();
        }

        /// <summary>
        /// Index all files under given directory (files in sub-directories included)
        /// </summary>
        /// <param name="path">Directory path to index</param>
        /// <returns>List of all file paths under given directory</returns>
        public static List<string> Index(string path)
        {
            #region Recursively Walk Through Sub-dirs
            var subdir = Directory.GetDirectories(path).ToList();
            if (subdir.Any())
            {
                //subdir.ForEach((element) => { });
                foreach (var dir in subdir)
                {
                    return subdir.Concat(Index(dir)).ToList();
                }
            }
            return subdir;
            #endregion
        }
    }
}
