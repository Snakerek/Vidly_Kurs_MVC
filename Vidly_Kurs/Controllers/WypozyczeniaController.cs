using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vidly_Kurs.Controllers
{
    public class WypozyczeniaController : Controller
    {
        public IActionResult Nowe()
        {
            return View();
        }
    }
}