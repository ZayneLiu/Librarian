using System;
using System.Collections.Generic;
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


        public class FolderResult
        {
            public string FolderName { get; set; }
            public string FolderPath { get; set; }
        }

        /// <summary>
        /// Get indexed folders.
        /// </summary>
        /// <returns>List of indexed folders</returns>
        [HttpGet("folders")]
        public ActionResult<List<FolderResult>> GetIndexedFolders()
        {
            var result = new List<FolderResult>();

            var folders = Custodian.Folders;
            folders.ForEach(folder =>
                result.Add(new FolderResult
                    {FolderName = folder.Location.Split(PathDelimiter).Last(), FolderPath = folder.Location})
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
            var result = Custodian.TakeCareOf(folderPath);
            // Console.WriteLine();
            var folderName = result.Location.Split(PathDelimiter).Last();

            return new JsonResult(
                new
                {
                    folder = new {location = result.Location, files = result.Documents.Count},
                    msg =
                        $"folder {folderName} is indexed with {result.Documents.Count} in total."
                }
            );
        }

        public class DocumentResult
        {
            public string DocumentName { get; set; }
            public Dictionary<string, int> Result { get; set; }
        }

        [HttpPost("search")]
        public ActionResult<List<DocumentResult>> Search(string keyword)
        {
            keyword = keyword.ToLower();
            var result = new List<DocumentResult>();
            var keywords = keyword.Split(" ");

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
                        DocumentName = currentDoc.Name,
                        Result = resultDict
                    }
                );
            }

            return result;
        }
    }
}
