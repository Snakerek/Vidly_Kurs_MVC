using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly_Kurs.Models;
using Vidly_Kurs.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Vidly_Kurs.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Vidly_KursContext _context; //Tworzymy prop dla kontextu bazy danych

        public CustomerController(Vidly_KursContext context) //Dependency injection
        {
            _context = context; //Ustawiamy kontext
        }

        public List<Customer> customers;

        public IActionResult Klienci()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            if (customers == null)
            {
            return View("BrakKlienta");
            }
            else
            {
               var viewModel = new CustomerViewModel { customers = customers };
            return View(viewModel); 
            }
            
            
        }

        public IActionResult Klient(int id)
        {
            /* Moje rozwiązanie stare bez DBContext
            if ((id < 0) || (customers == null))
            {
                return View("BrakKlienta");

            }
            else
            {
                if (customers.Count - 1 < id)
                {
                    return View("BrakKlienta");
                }
                else
                {
                    return View(customers[id]);
                }
            }
            */
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); //Pobieramy dane klienta o podanym id
            if (customer == null)
                return View("BrakKlienta"); //Jeżeli nie ma takiego klienta to zwracamy widok z brakiem takiego klienta
            return View(customer); //Jeżeli klient istnieje to pokazujemy informacje o nim
        }

        public IActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel{MembershipTypes = membershipTypes};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new  CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()               
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.Id==0)
            {
              _context.Customers.Add(customer);
              
            }
            else
            {
                var customerDB = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerDB.Name = customer.Name;
                customerDB.BirthdayDate = customer.BirthdayDate;
                customerDB.Id = customer.Id;
                customerDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerDB.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Klienci");
        }

        public IActionResult Edytuj(int id)
        {
            try
            {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerFormViewModel {Customer = customer, MembershipTypes = _context.MembershipType.ToList()};
            return View("CustomerForm",viewModel);
            }
            catch (Exception e)
            {
                return NotFound();
            }
           
        }
    }
}