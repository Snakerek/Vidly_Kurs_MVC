using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly_Kurs.Models;

namespace Vidly_Kurs.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly Vidly_KursContext _context;
        public MoviesController(Vidly_KursContext context)
        {
            _context = context;
        }
        // GET: api/Movies
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<ActionResult<Movie>> GetMovieAsync(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovieAsync([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovie", new {id = movie.Id}, movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovieAsync(int id, [FromBody] Movie movie)
        {
            var movieInDb =await _context.Movies.SingleOrDefaultAsync(m=>m.Id == id);
            if (movieInDb == null) 
            {
                return NotFound();
            }

            movieInDb.Name = movie.Name;
            movieInDb.DataDodaniaDoKatalogu = movie.DataDodaniaDoKatalogu;
            movieInDb.DataWydania = movie.DataWydania;
            movieInDb.GatunekId = movie.GatunekId;
            movieInDb.IloscDostepnychKopi = movie.IloscDostepnychKopi;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovieAsync(int id)
        {
            var movieInDb = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);
            if (movieInDb==null)
            {
                return BadRequest();
            }

            _context.Remove(movieInDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
