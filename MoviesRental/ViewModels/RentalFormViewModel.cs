using MoviesRental.Models;
using System.Collections.Generic;

namespace MoviesRental.ViewModels
{
    public class RentalFormViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public Rental Rental { get; set; }
        public string ErrorMessage { get; set; }
    }
}
