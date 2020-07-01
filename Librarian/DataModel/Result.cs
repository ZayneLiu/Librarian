using System;
using Foundation;

namespace Librarian.Models
{
    //[Register("FileModel")]
    public class Result : NSObject
    {
        #region Computed Properties
        public string Name { get; set; } = "";
        public string Similarity { get; set; } = "";
        public string Path { get; set; } = "";
        #endregion

        #region Constructors
        public Result()
        {
        }

        public Result(string name, string similarity, string path)
        {
            this.Name = name;
            this.Similarity = similarity;
            this.Path = path;
        }
        #endregion
    }


}
