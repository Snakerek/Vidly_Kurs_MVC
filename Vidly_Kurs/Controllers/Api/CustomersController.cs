using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Vidly_Kurs.DTO;
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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        //GET /api/customers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Mapper.Map<Customer,CustomerDTO>(customer);
        }

        //POST /api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
           await _context.Customers.AddAsync(customer);
           await _context.SaveChangesAsync();
            customerDto.Id = customer.Id;
            return CreatedAtAction("GetCustomer",new {id = customerDto.Id}, customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync(int id, CustomerDTO customerDto)
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

            Mapper.Map(customerDto, customerInDb);

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