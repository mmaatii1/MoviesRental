using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Display(Name = "Genre")]
        public string GenreName  { get; set; }
    }
}
