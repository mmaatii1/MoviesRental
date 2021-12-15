using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MoviesRental.Models;

namespace MoviesRental.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required]
        public string MovieName { get; set; }

        
        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public GenreDto Genre { get; set; }
        [Required]
        [Display(Name = "Date of release")]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Display(Name = "Number in stock")]
        [Required]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public string MovieImageString { get; set; }
    }
}
