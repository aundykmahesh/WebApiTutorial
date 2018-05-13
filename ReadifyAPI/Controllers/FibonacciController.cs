using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ReadifyAPI.Controllers
{
    /// <summary>
    /// Returns the nth fibonacci number
    /// </summary>
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
      
        /// <summary>
        /// Returns the nth fibonacci number.
        /// </summary>
        /// <remarks>
        /// fibonacci
        /// </remarks>
        /// <param name='n'>
        ///     <description>The index (n) of the fibonacci sequence</description>
        /// </param>
        /// <returns>nth Fibonacci number</returns>
        [HttpGet]
        public ContentResult Get([FromQuery] int? n)
        {

            if (n == null)
            {
                return Content("{\"message\":\"The request is invalid.\"}");
            }
            int? m = (n < 0) ? n * -1 : n;
            long firstnumber = 0;
            long secondnumber = 1;
            for (var counter = 1; counter < m; counter++)
            {
                secondnumber += firstnumber;
                if (secondnumber < 0) return Content("{\"message\":\"The request is invalid.\"}");
                firstnumber = secondnumber - firstnumber;
            }
            secondnumber = (n < 0 && n%2==0) ? secondnumber * -1 : secondnumber;
            return Content((n == 0) ? 0.ToString() : secondnumber.ToString());
        }

    
    }
}