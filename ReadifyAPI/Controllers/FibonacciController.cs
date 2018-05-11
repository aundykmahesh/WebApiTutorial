using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
        // GET api/documentation
        /// <summary>
        /// Returns the nth fibonacci number
        /// </summary>
        /// <returns>Returns the nth fibonacci number</returns>
        //[HttpGet("{n}")]
        [HttpGet]
        public JsonResult Get([FromQuery] long? n)
        {

            if (n == null) return Json("Invalid Request");
            long firstnumber = 0, secondnumber = 1;
            for (var i = 1; i < n; i++)
            {
                if (i == 1) secondnumber = 1;
                secondnumber += firstnumber;
                if (secondnumber < 0) return Json(string.Empty);
                firstnumber = secondnumber - firstnumber;
            }
            return Json((n == 0) ? 0 : secondnumber);
        }
    }
}