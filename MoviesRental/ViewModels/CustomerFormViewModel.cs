using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesRental.Models;

namespace MoviesRental.ViewModels
{
    public class CustomerFormViewModel
    {

        public IEnumerable<MemberShip> MemberShips { get; set; }
        public Customer Customer { get; set; }
    }
}
