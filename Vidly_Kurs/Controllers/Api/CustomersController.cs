using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Vidly_Kurs.Models;

namespace Vidly_Kurs.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private Vidly_KursContext _context;
        public CustomersController(Vidly_KursContext vidlyKursContext)
        {
            _context = vidlyKursContext;
        }
        //GET /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        //POST /api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomerAsync(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
           await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer",new {id = customer.Id}, customer);
        }

        //PUT /api/customers/1
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb==null)
            {
                return NotFound();
            }

            customerInDb.Name = customer.Name;
            customerInDb.BirthdayDate = customer.BirthdayDate;
            customerInDb.Id = customer.Id;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<Customer>> DeleteCustomerAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
           await _context.SaveChangesAsync();
            return customerInDb;
        }
    }
}