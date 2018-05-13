using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    /// <summary>
    /// Default controller used for redirection
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Default action used for redirection to swagger
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi =true)]
        public IActionResult Index()
        {
            return Redirect("swagger");
        }

    }
}