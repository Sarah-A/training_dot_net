﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AspDotNetCourseApp.Models;
using AspDotNetCourseApp.Dtos;
using System.Data.Entity;

namespace AspDotNetCourseApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);    
        }

        private Movie GetMovieInDb(int id)
        {            
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }

        // GET api/movies
        public IHttpActionResult GetMovies(string filterForRenting = null)
        {
            var moviesInDb = _context.Movies
                                     .Include(m => m.Genre);

            if (!String.IsNullOrWhiteSpace(filterForRenting))
            {
                moviesInDb = moviesInDb.Where(m => (m.Name.Contains(filterForRenting) &&
                                       m.NumberAvailable > 0));
            }

            var moviesDtos = moviesInDb
                                .ToList()
                                .Select(Mapper.Map<MovieDto>);

            return Ok(moviesDtos);
        }

        // GET api/movies/{id}
        public IHttpActionResult GetMovie(int id)
        {
            var movie = GetMovieInDb(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<MovieDto>(movie));
        }

        // POST api/movies
        [Authorize(Roles = RoleNames.Admin)]
        [HttpPost]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        // PUSH api/movies/{id}
        [Authorize(Roles = RoleNames.Admin)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = GetMovieInDb(id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }


        // DELETE api/movies/{id}
        [Authorize(Roles = RoleNames.Admin)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = GetMovieInDb(id);
            if( movieInDb == null )
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
