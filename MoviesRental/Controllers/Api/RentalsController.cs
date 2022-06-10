using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MoviesRental.Data;
using MoviesRental.Dtos;
using MoviesRental.Models;

namespace MoviesRental.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RentalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RentalsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Include(c => c.MemberShip).Single(c => c.Id == newRentalDto.CustomerId);
            int discount = customer.MemberShip.DiscountInProcent;

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("No movie in stock");
                movie.NumberInStock--;

                var movierealseTimeSpan = DateTime.Today.Year - movie.ReleaseDate.Value.Year;
                
                var price = movierealseTimeSpan > 2 ? 30 : 45;


                var rental = new Rental
                {
                    Customer = customer,
                    DateRented = DateTime.Now,
                    Movie = movie,
                    Price = (int)(price - (price * discount*0.01)),

                };
                _context.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetNewRentals()
        {
            var rentals = _context.Rentals.Include(c => c.Customer).Include(m => m.Movie).ToList().Select(_mapper.Map<Rental,NewRentalDto>);
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public IActionResult GetRental(int id)
        {
            var movie = _context.Rentals.Include(c => c.Customer).Include(m => m.Movie).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                NotFound();

            return Ok(_mapper.Map<Rental, NewRentalDto>(movie));
        }

        [HttpPut]
        public IActionResult UpdateRental(int id, NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);
            if (rentalInDb == null)
                return NotFound();

            _mapper.Map<NewRentalDto, Rental>(newRentalDto, rentalInDb);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(c => c.Id == id);
            if (rentalInDb == null)
                NotFound();

            if(rentalInDb.DateReturned == null)
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == rentalInDb.MovieId);
                movie.NumberInStock++;
            }
            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
            return Ok();
        }
    }

    
}
