using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesRental.Models;

namespace MoviesRental.Dtos
{
    public class NewRentalDto
    {

        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public MovieDto Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public int Price { get; set; }
    }
}
