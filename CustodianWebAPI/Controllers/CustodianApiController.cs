using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using CustodianAPI;
using Microsoft.AspNetCore.Mvc;

namespace CustodianWebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class CustodianApiController : Controller
    {
        public static readonly Custodian Custodian = new Custodian();
        public static readonly char PathDelimiter = Path.DirectorySeparatorChar;


        /// <summary>
        /// Get indexed folders.
        /// </summary>
        /// <returns>List of indexed folders</returns>
        [HttpGet("folders")]
        public ActionResult<List<FolderResult>> GetIndexedFolders()
        {
            var result = new List<FolderResult>();

            var folders = Custodian.Folders;
            folders.ForEach(
                folder => result.Add(
                    new FolderResult
                    {
                        FolderName = folder.Location.Split(PathDelimiter).Last(),
                        FolderPath = folder.Location
                    })
            );
            return result;
        }


        /// <summary>
        /// Index given folder.
        /// </summary>
        /// <param name="folderPath">Path to the folder to be indexed.</param>
        /// <returns>Indexed folder info.</returns>
        [HttpPost("folders")]
        public IActionResult IndexGivenFolder(string folderPath)
        {
#if DEBUG
            if (folderPath == null) folderPath = "/Users/zayne/Workspace/__Data__/Files";
#endif

            var result = Custodian.TakeCareOf(folderPath);
            // Console.WriteLine();
            var folderName = result.Location.Split(PathDelimiter).Last();

            return new JsonResult(
                new
                {
                    folder = new { location = result.Location, files = result.Documents.Count },
                    msg =
                        $"folder {folderName} is indexed with {result.Documents.Count} in total."
                }
            );
        }


        [HttpPost("search")]
        public ActionResult<List<DocumentResult>> Search(string keyword)
        {
            keyword = keyword.ToLower();
            var result = new List<DocumentResult>();
            var keywords = keyword.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(Custodian.Search(keywords));
            using var resultDocList = Custodian.Search(keywords).GetEnumerator();
            while (resultDocList.MoveNext())
            {
                var currentDoc = resultDocList.Current;
                if (currentDoc == null)
                    throw new Exception("No Doc!");

                var resultDict = keywords.ToDictionary(kw => kw, kw => currentDoc.Thumbnail[kw]);
                result.Add(
                    new DocumentResult()
                    {
                        Name = currentDoc.Name,
                        Path = currentDoc.Location,
                        Result = resultDict
                    }
                );
            }

            return result;
        }

        public class FolderResult
        {
            [Required] public string FolderName { get; set; }

            [Required] public string FolderPath { get; set; }
        }

        public class DocumentResult
        {
            /// <summary>
            /// File name of the document.
            /// </summary>
            [Required]
            public string Name { get; set; }

            /// <summary>
            /// Path of the document.
            /// </summary>
            [Required]
            public string Path { get; set; }

            /// <summary>
            /// Key-value pairs of each keyword and its occurrences.
            /// </summary>
            [Required]
            public Dictionary<string, int> Result { get; set; }
        }
    }
}
