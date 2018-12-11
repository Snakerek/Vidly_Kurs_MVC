using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly_Kurs.Models;
using Vidly_Kurs.ViewModels;

namespace Vidly_Kurs.Controllers
{
    public class MovieController : Controller
    {
        private readonly Vidly_KursContext _context;

        public MovieController(Vidly_KursContext context)
        {
            _context = context;
        }
        //GET: /Movie/Movies
        public IActionResult Movies()
        {
            var movies = _context.Movies.Include(g => g.Gatunek).ToList();
            if (movies == null)
            {
                return NotFound();
            }
            else
            {
                return View("Movies", new MoviesViewModel{Movies = movies});
            }
            
        }

        public IActionResult MovieForm(int? id)
        {
            var gatunki = _context.Gatunek.ToList();
            if (id!=null)
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
                var movieViewModel = new MoviesFormViewModel{Gatunek = gatunki, Movie = movie};
                return View("MovieForm", movieViewModel);
            }
            else
            {
                return View("MovieForm", new MoviesFormViewModel { Gatunek = gatunki});
            } 
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDB = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieDB.Name = movie.Name;
                movieDB.DataDodaniaDoKatalogu = movie.DataDodaniaDoKatalogu;
                movieDB.DataWydania = movie.DataWydania;
                movieDB.GatunekId = movie.GatunekId;
                movieDB.IloscDostepnychKopi = movie.IloscDostepnychKopi;
            }

            _context.SaveChanges();
            return RedirectToAction("Movies");
        }

        public IActionResult Film(int id)
        {
            var movie = _context.Movies.Include(g=>g.Gatunek).SingleOrDefault(i => i.Id == id);
            if (movie==null)
            {
                return NotFound();
            }
            else
            {
               return View("Film", movie); 
            }
            
        }
        //GET: Movie/Random
        public IActionResult Random()
        {
            var movie = new Movie(){Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Klien 1"},
                new Customer {Name = "Klient 2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Siemka");
            //return NotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new  {page =1 , sortBy = "name"});
        }

        public IActionResult Edit(int movieId)
        {
            return Content("movieId=" + movieId);
        }
        //movie
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex, sortBy));
        }

        [Route("Movie/released/{year}/{month:range(1,12)}")]//
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
        
    }
}