using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    /// <summary>
    /// Aundy's token
    /// </summary>
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        // GET api/documentation
        /// <summary>
        /// Aundy's Token
        /// </summary>
        /// <returns>Token</returns>
        [HttpGet]
        public JsonResult Get()
        {
            return Json("f440f48b-1952-48e7-9cdc-6d20e7533515");
        }
    }
}