using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class NoweWypozyczenie
    {
        public int CustomerId { get; set; }
        public List<int> MovieIDs { get; set; }
    }
}
