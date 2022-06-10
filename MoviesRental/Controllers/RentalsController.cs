using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MoviesRental.Data;
using Microsoft.EntityFrameworkCore;
using MoviesRental.ViewModels;
using MoviesRental.Models;

namespace MoviesRental.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult New()
        {
            var viewModel = new NewRentalFormViewModel
            {
                Customers = _context.Customers.ToList(),
                Movies = _context.Movies.ToList(),
                MoviesIds = new List<int>(),
                Rental = new Rental(),
            };
            return View(viewModel);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Movie.Genre)
                .Include(r => r.Customer)
                .Include(r => r.Customer.MemberShip)
                .SingleOrDefault(m => m.Id == id);
            if (rental == null)
                return NotFound();
            return View(rental);
        }

        public IActionResult Edit(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .SingleOrDefault(m => m.Id == id);
            if (rental == null)
                return NotFound();
            var viewModel = new RentalFormViewModel
            {
                Customers = _context.Customers.ToList(),
                Movies = _context.Movies.ToList(),
                Rental = rental
            };
            return View("RentalForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Rental rental)
        {
            if (!ModelState.IsValid || rental.Id == 0)
            {
                var viewModel = new RentalFormViewModel
                {
                    Customers = _context.Customers.ToList(),
                    Movies = _context.Movies.ToList(),
                    Rental = rental
                };
                return View("RentalForm", viewModel);
            }

            else
            {
                var rentalInDb = _context.Rentals.Single(m => m.Id == rental.Id);
                if (!EditMovieInStock(rental, rentalInDb))
                {
                    var viewModel = new RentalFormViewModel
                    {
                        Customers = _context.Customers.ToList(),
                        Movies = _context.Movies.ToList(),
                        Rental = rentalInDb,
                        ErrorMessage = "No movie in stock"
                    };

                    return View("RentalForm", viewModel);
                }


                rentalInDb.DateReturned = rental.DateReturned;
                rentalInDb.DateRented = rental.DateRented;
                rentalInDb.Price = rental.Price;
                rentalInDb.CustomerId = rental.CustomerId;
                rentalInDb.MovieId = rental.MovieId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Rentals");
        }

        private bool EditMovieInStock(Rental rentalEdited, Rental rentalInDb)
        {
            if (rentalInDb.DateReturned != null && rentalEdited.DateReturned == null)
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == rentalEdited.MovieId);
                if (movie.NumberInStock == 0)
                    return false;
                movie.NumberInStock--;
            }
            else if (rentalInDb.DateReturned == null && rentalEdited.DateReturned != null)
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == rentalInDb.MovieId);
                movie.NumberInStock++;
            }
            else if (rentalInDb.DateReturned == null && rentalEdited.DateReturned == null)
            {
                if (rentalInDb.MovieId != rentalEdited.MovieId)
                {
                    var movieIncreaseInStock = _context.Movies.SingleOrDefault(m => m.Id == rentalInDb.MovieId);
                    var movieToDecreaseInStock = _context.Movies.SingleOrDefault(m => m.Id == rentalEdited.MovieId);
                    
                    if (movieToDecreaseInStock.NumberInStock == 0)
                        return false;
                    movieIncreaseInStock.NumberInStock++;
                    movieToDecreaseInStock.NumberInStock--;
                }
            }

            return true;
        }
    }
}
