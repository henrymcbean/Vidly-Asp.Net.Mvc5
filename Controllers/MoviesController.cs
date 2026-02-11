using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Asp.Net.Mvc5.Models;

namespace Vidly_Asp.Net.Mvc5.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
        }
    }
}   