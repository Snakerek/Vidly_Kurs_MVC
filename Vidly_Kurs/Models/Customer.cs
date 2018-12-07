using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Customer> Customers { get; set; }

    }
}
