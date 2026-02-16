using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using Vidly_Asp.Net.Mvc5.Dto;
using Vidly_Asp.Net.Mvc5.Models;
using AutoMapper;

namespace Vidly_Asp.Net.Mvc5.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInd = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInd == null)
            {
                NotFound();
            }
            else
            {
                _context.Movies.Remove(movieInd);
                _context.SaveChanges();
            }
        }
    }
}
