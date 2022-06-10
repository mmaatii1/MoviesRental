using MoviesRental.Models;
using System.Collections.Generic;

namespace MoviesRental.ViewModels
{
    public class NewRentalFormViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<int> MoviesIds { get; set; }
        public Rental Rental { get; set; }
    }
}
