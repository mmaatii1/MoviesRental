using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Models
{
    public class MemberShip
    {
        public byte Id { get; set; }
        public short Fee { get; set; }
        [Display(Name = "Membership name")]
        public string Name { get; set; }
        [Display(Name = "Duration of membership in months")]
        public byte DurationInMonths { get; set; }
        [Display(Name = "Discount in %")]
        public byte DiscountInProcent { get; set; }

        public static readonly byte Free = 1;
        public static readonly byte MinAge = 18;
    }
}
