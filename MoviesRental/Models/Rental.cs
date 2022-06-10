using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Customer is required")]
        public int? CustomerId { get; set; }
        public Movie Movie { get; set; }
        [Required(ErrorMessage = "Movie is required")]
        public int? MovieId { get; set; }
        [Display(Name = "Date rented")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateRented { get; set; }
        [Display(Name = "Date returned")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateReturned { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
