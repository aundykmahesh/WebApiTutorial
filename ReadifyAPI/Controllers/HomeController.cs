using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReadifyAPI.Controllers
{
    //Comment the routing when working with swagger
    [Route("")]
    [Route("api")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Invalid Action";
        }

    }
}