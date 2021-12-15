using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MoviesRental.Models;

namespace MoviesRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Display(Name = "Subscribed to NewsLetter?")]
        public bool IsSubscirbedToNewsLetter { get; set; }

        public MemberShipDto MemberShip { get; set; }
        
        public byte MemberShipId { get; set; }


        
        
        public DateTime? DateOfBirth { get; set; }
    }
}
