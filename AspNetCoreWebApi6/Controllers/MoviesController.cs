﻿using AspNetCoreWebApi6.DatabaseContext;
using AspNetCoreWebApi6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            return await _dbContext.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            Movie movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new {id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutMovie(int id, Movie movie)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            if (movie == null || id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                _dbContext.Entry(movie).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return (_dbContext.Movies?.Any(m => m.Id == id)).GetValueOrDefault();
        }
    }
}
