using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StarCinema.Controllers.CRUDControllers
{
    public class CityController : Controller
    {
        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }
    }
}