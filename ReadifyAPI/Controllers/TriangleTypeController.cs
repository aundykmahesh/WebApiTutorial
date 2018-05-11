using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    [Route("api/[controller]")]
    public class TriangleTypeController : Controller
    {
        // GET api/documentation
        /// <summary>
        /// Returns the nth fibonacci number
        /// </summary>
        /// <returns>Returns the nth fibonacci number</returns>
        //[HttpGet("{n}")]
        [HttpGet]
        public JsonResult Get([FromQuery] int a, int b, int c)
        {
            if (a == b && b == c)
            {
                return Json("Equilateral");
            }
            if (a != b && b != c && a != c)
            {
                return Json("Scalene");
            }

            return Json("Isosceles");
        }
    }
}