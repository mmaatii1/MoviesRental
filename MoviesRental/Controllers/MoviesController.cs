using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesRental.Data;
using MoviesRental.Models;
using MoviesRental.ViewModels;

namespace MoviesRental.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MoviesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult New()
        {
            
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres,
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();
                var movieViewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = genres,
                };
                return View("MovieForm",movieViewModel);
            }

            if (movie.Id == 0)
            {
                var moviee = movie;
                moviee.DateAdded = DateTime.Today;
                _context.Movies.Add(moviee);
            }
                
            else
            {
                var movieInDb = _context.Movies.Single(m =>m.Id == movie.Id);
                movieInDb.MovieName = movie.MovieName;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Today;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie,
            };
            return View("MovieForm", viewModel);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }
    }
}
