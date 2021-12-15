using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required]
        public string MovieName { get; set; }

        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
        
        [Required]
        [Display(Name = "Date of release")]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Number in stock")]
        [Required]
        [Range(1,20)]
        public byte? NumberInStock { get; set; }

        public string MovieImageString { get; set; }
    }
}
