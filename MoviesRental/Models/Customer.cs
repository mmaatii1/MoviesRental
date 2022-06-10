using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer name")]
        public string Name { get; set; }

        
        [Display(Name = "Subscribed to NewsLetter?")]
        public bool IsSubscirbedToNewsLetter { get; set; }

        
        
        public MemberShip MemberShip { get; set; }

        
        [Display(Name = "MemberShip Type")]
        [Required]
        public byte? MemberShipId { get; set; }

       
        [Display(Name = "Date of birth")]
        [Min18Yo]
        public DateTime? DateOfBirth { get; set; }
    }
}
