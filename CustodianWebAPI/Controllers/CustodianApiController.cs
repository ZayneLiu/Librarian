using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace CustodianWebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class CustodianApiController : Controller
    {
        // GET
        /// <summary>
        /// Get indexed folders
        /// </summary>
        /// <returns>List of indexed folders</returns>
        [HttpGet("folders")]
        public IActionResult GetIndexedFolders()
        {
            return new JsonResult(new[] {"a"});
        }

        [HttpPost("folders")]
        public IActionResult IndexGivenFolder(string folderPath)
        {
            return new JsonResult(
                new {msg=$"folder {folderPath} is indexed."}
            );
        }

        [HttpGet()]
        public IActionResult Search(string keyword)
        {
            return new JsonResult(new {result = "aaa"});
        }
    }
}
