using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReadifyAPI.Controllers
{
    /// <summary>
    /// Returns the type of triange given the lengths of its sides
    /// </summary>
    [Route("api/[controller]")]
    public class TriangleTypeController : Controller
    {
        // GET api/documentation
        /// <summary>
        /// Returns the type of triange given the lengths of its sides
        /// </summary>
        /// <returns>Type of triangel based on sides</returns>
        /// <param name="a"><description>The length of side a
        /// </description></param>
        /// <param name="b"><description>The length of side b
        /// </description></param>
        /// <param name="c"><description>The length of side c
        /// </description></param>
        [HttpGet]
        [ExceptionHandling]
        //[HttpGet]
        public ContentResult Get([FromQuery] int? a, int? b, int? c)
        {
            string triangletype = string.Empty;
            triangletype = "Isosceles";

            if (a==null || b==null || c==null)
            {
                return Content("{\"message\":\"The request is invalid.\"}");
            }
            if (a == 0 && c == 0 & b==0) return Content("\"Error\"");

             if (a == b && b == c)
            {
                triangletype= "Equilateral";
            }
            if (a != b && b != c && a != c)
            {
                triangletype = "Scalene";
            }

            if (a+b<=c || b+c<=a || a+c<=b)
            {
                return Content("\"Error\"");
            }
            return Content(JsonConvert.SerializeObject(triangletype));
        }
    }
}