using System.IO;

namespace CustodianAPI.Test
{
    public class SharedTestData
    {
        public static string ProjectDirectory
        {
            get
            {
                // Get path to "./bin/Debug/netcoreapp3.1"
                var currentWorkingDirectory = Directory.GetCurrentDirectory();
                // Get project path "./"
                return Directory.GetParent(currentWorkingDirectory).Parent.Parent.FullName;
            }
        }
        public static string TestDocFolderPath = $"{ProjectDirectory}/Test Doc/";
    }

}