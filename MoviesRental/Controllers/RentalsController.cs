using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
