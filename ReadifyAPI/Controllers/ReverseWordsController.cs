using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    /// <summary>
    /// Reverses the letters of each word in a sentence.
    /// </summary>
    [Route("api/[controller]")]
    public class ReverseWordsController : Controller
    {
        // GET api/documentation
        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <returns>Reverse word</returns>
        /// <param name='sentence'>
        ///     <description>A Sentence</description>
        /// </param>
        [HttpGet]
        public JsonResult Get([FromQuery] string sentence)
        {
            if (sentence == null) return Json(string.Empty);
            String[] stringarr = sentence.Split(' ');
            var result = string.Empty;
            
            foreach (var item in stringarr)
            {
                for (int i = item.Length; i>0; i--)
                {
                    result += item[i-1];
                }
                result += " ";
            }
            
            return Json(result.Remove(result.Length-1));
        }
    }
}