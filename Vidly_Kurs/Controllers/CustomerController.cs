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
        public List<Customer> customers = new List<Customer>
        {
            new Customer{Name = "Klient 1", Id = 0},
            new Customer{Name = "Klient 2", Id = 1},
            new Customer{Name = "Klient 3", Id = 2},
            new Customer{Name = "Klient 4", Id = 3},
            new Customer{Name = "Klient 5", Id = 4}
        };
        
        public IActionResult Klienci()
        {
            if (customers == null)
            {
            return View("BrakKlienta");
            }
            else
            {
               var viewModel = new Customer{Customers = customers};
            return View(viewModel); 
            }
            
            
        }

        public IActionResult Klient(int id)
        {
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
        }
    }
}