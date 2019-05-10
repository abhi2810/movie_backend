using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movie_backend.Models;

namespace movie_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastsController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public MovieCastsController(CatalogueContext context)
        {
            _context = context;
            _context.MovieCasts.Add(new MovieCast());
            _context.SaveChanges();
        }

        // GET: api/MovieCasts
        [HttpGet]
        public IEnumerable<MovieCast> GetMovieCasts()
        {
            return _context.MovieCasts;
        }

        // GET: api/MovieCasts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieCast([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieCast = await _context.MovieCasts.FindAsync(id);

            if (movieCast == null)
            {
                return NotFound();
            }

            return Ok(movieCast);
        }

        // PUT: api/MovieCasts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieCast([FromRoute] int id, [FromBody] MovieCast movieCast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieCast.id)
            {
                return BadRequest();
            }

            _context.Entry(movieCast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieCasts
        [HttpPost]
        public async Task<IActionResult> PostMovieCast([FromBody] MovieCast movieCast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MovieCasts.Add(movieCast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieCast", new { id = movieCast.id }, movieCast);
        }

        // DELETE: api/MovieCasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieCast([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieCast = await _context.MovieCasts.FindAsync(id);
            if (movieCast == null)
            {
                return NotFound();
            }

            _context.MovieCasts.Remove(movieCast);
            await _context.SaveChangesAsync();

            return Ok(movieCast);
        }

        private bool MovieCastExists(int id)
        {
            return _context.MovieCasts.Any(e => e.id == id);
        }
    }
}