using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Asp.Net.Mvc5.Dto;
using Vidly_Asp.Net.Mvc5.Models;

namespace Vidly_Asp.Net.Mvc5.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieId.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
