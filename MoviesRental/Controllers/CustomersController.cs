using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MoviesRental.Data;
using MoviesRental.Models;
using MoviesRental.ViewModels;

namespace MoviesRental.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m => m.MemberShip).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                NotFound();
            return View(customer);
        }

        
        public IActionResult New()
        {
            var membership = _context.MemberShips.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MemberShips = membership,
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //token generowany jest w CustomerForm, i jest przechowany jako zaszyfrowany string w cookie na hoscie, oraz jako zaszyfrowany string w przycisku, zapobiega atakom CSRF cross-site request forgery
                                    //jezeli token w cookie == token w sumbit jest git 
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                
                //jezeli form jest zle wypelniony to generujmy ten sam view z dobrze wypelnionymi polami
                var viewmodel = new CustomerFormViewModel 
                {
                    Customer = customer,
                    MemberShips = _context.MemberShips.ToList(),
                };
                return View("CustomerForm", viewmodel);
            }

            if (customer.Id == 0) //jezeli customer ma id zero oznacza to ze jest nowy, dodajemy go do bazy
                _context.Customers.Add(customer);

            else //jezeli nie ma id zero to modyfikujemy danego klienta identyfikujac go po id
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.IsSubscirbedToNewsLetter = customer.IsSubscirbedToNewsLetter;
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MemberShipId = customer.MemberShipId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShips = _context.MemberShips.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}
