using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly_Kurs.Models;
using Vidly_Kurs.ViewModels;

namespace Vidly_Kurs.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Klienci()
        {
            var customers = new  List<Customer>
            {
                new Customer{Name = "Klient 1", Id = 0},
                new Customer{Name = "Klient 2", Id = 1},
                new Customer{Name = "Klient 3", Id = 2},
                new Customer{Name = "Klient 4", Id = 3},
                new Customer{Name = "Klient 5", Id = 4}
            };
            var viewModel = new CustomersViewModel {Customers = customers};
            return View(viewModel);
            //return Content("asdfasd");
        }

        public IActionResult Klient(int id, string name)
        {
            var customer = new Customer {Id = id, Name = name};
            return View(customer);
        }
    }
}