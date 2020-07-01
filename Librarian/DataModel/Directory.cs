using System;
using Foundation;

namespace Librarian.DataModel
{
    public class Directory
    {
        public Directory()
        {
        }

        public Directory(string path)
        {
            this.Path = path;
        }

        public string Path { get; set; } = "";
    }
}
