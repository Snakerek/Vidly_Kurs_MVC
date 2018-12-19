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
    public class WyporzyczeniaController : ControllerBase
    {
        private readonly Vidly_KursContext _context;
        public WyporzyczeniaController(Vidly_KursContext context)
        {
            _context = context;
        }

        //GET: /api/wypozyczenia
        [HttpGet]
        public async Task<IEnumerable<Wyporzyczenia>> GetWypozyczeniaAsync()
        {
            var wypozyczenia =await _context.Wyporzyczenia.Include(c => c.Customer).Include(m => m.Movie).ToListAsync();
            return wypozyczenia;
        }

        //Get: /api/wypozyczenia/1
        [HttpGet("id")]
        public async Task<ActionResult<Wyporzyczenia>> GetWypozyczenieAsync(int id)
        {
            var wypozyczenie = await _context.Wyporzyczenia.Include(c => c.Customer).Include(m => m.Movie).SingleOrDefaultAsync(w => w.Id == id);
            if (wypozyczenie==null)
            {
                return NotFound();
            }
            return wypozyczenie;
        }


        [HttpPost]
        public async Task<ActionResult<NoweWypozyczenie>> AddWypozyczenieAsync([FromBody] NoweWypozyczenie noweWypozyczenie)
        {
            if (noweWypozyczenie.MovieIDs.Count == 0)
            {
                return BadRequest("Brak filmów na liście wypożyczeń");
            }
            var customer =await _context.Customers.SingleOrDefaultAsync(c => c.Id == noweWypozyczenie.CustomerId);
            if (customer==null)
            {
                return BadRequest("Nieprawidłowe ID klienta");
            }

            var movies = _context.Movies.Where(m => noweWypozyczenie.MovieIDs.Contains(m.Id)).ToList();

            if (movies.Count != noweWypozyczenie.MovieIDs.Count)
            {
                return BadRequest("Nie załadowano filmu");
            }
            foreach (var movie in movies)
            {
                if (movie.IloscDostepnychKopi==0)
                {
                    return BadRequest(movie.Name + " jest niedostępny do wypożyczenia");
                }
                movie.IloscDostepnychKopi--;
                var wypozyczenie = new Wyporzyczenia
                {
                    Customer = customer,
                    CustomerId = customer.Id,
                    Movie = movie,
                    MovieId = movie.Id,
                    DataWyporzyczenia = DateTime.Now
                };
                await _context.Wyporzyczenia.AddAsync(wypozyczenie);
            }
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/wypozyczenia/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Wyporzyczenia>> ZwrotFilmuAsync(int id, [FromBody] Wyporzyczenia wyporzyczenia)
        {
            var wypInDb = await _context.Wyporzyczenia.SingleOrDefaultAsync(m => m.Id == id);
            if (wypInDb == null)
            {
                return NotFound();
            }

            wypInDb.DataZwrotu = wyporzyczenia.DataZwrotu;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        // DELETE: api/wypozyczenia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wyporzyczenia>> DeleteWypozyczenieAsync(int id)
        {
            var wypInDb = await _context.Wyporzyczenia.SingleOrDefaultAsync(m => m.Id == id);
            if (wypInDb == null)
            {
                return BadRequest();
            }

            _context.Remove(wypInDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}