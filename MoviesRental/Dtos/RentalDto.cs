using System;

namespace MoviesRental.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public MovieDto Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public int Price { get; set; }
    }
}
