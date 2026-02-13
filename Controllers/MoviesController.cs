using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Asp.Net.Mvc5.Models;
using Vidly_Asp.Net.Mvc5.ViewModels;

namespace Vidly_Asp.Net.Mvc5.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult New()
        {
            var movieForm = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieFormView", movieForm);
        }

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieFormView", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieIdb = _context.Movies.Single(m => m.Id == movie.Id);
                movieIdb.Name = movie.Name;
                movieIdb.GenreId = movie.GenreId;
                movieIdb.DateAdded = movie.DateAdded;
                movieIdb.ReleaseDate = movie.ReleaseDate;
                movieIdb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieFormView", viewModel);
        }
    }
}   