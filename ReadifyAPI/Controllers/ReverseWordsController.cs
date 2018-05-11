using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReverseWordsController : Controller
    {
        // GET api/documentation
        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <returns>Reverse word</returns>
        [HttpGet]
        public JsonResult Get([FromQuery] string sentence)
        {
            if (sentence == null) return Json(string.Empty);
            var reverse = sentence.Reverse();
            var result = string.Empty;
            foreach (var item in reverse)
            {
                result += item;
            }
            return Json(result);
        }
    }
}