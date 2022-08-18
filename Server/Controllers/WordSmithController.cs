////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: WordSmithController.cs
//FileType: Visual C# Source file
//Author : Steve Simonton
//Created On : 8/15/2022
//Last Modified On : 
//Copy Rights : TechTock LLC
//Description : Everything books
////////////////////////////////////////////////////////////////////////////////////////////////////////


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Text;
using WordSmith.Services.Interfaces;
using WordSmithWeb.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordSmith.Controllers
{
    /// <summary>
    /// Everything books controller
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WordSmithController : ControllerBase
    {
        /// <summary>
        /// This is the underlying service that will process all of the WordSmith's functionality
        /// </summary>
        IBookService _service;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="service"></param>
        public WordSmithController(IBookService service)
        {
            _service = service;
        }

        /// <summary>
        /// Count the number of words in text
        /// </summary>
        /// <param name="bookRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Words/Count")]
        [ProducesResponseType(typeof(List<string>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CountWords([FromBody] UploadedBookRequest bookRequest)
        {
            List<WordResult> words = new List<WordResult>();

            try
            {
                //Get the string from the uploadedFile.BookContent
                string book = Encoding.UTF8.GetString(bookRequest.BookContent, 0, bookRequest.BookContent.Length);

                //Get the string from the uploadedFile.IgnoreWordsContent
                string ignoreWords = Encoding.UTF8.GetString(bookRequest.IgnoreWordsContent, 0, bookRequest.IgnoreWordsContent.Length);

                //Get all of the words and how many times they were used in the text
                words = _service.GetFrequencyFromLines(book, ignoreWords, bookRequest.RequestedResults);

                return Ok(words);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
