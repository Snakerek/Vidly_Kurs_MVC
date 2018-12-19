using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class Wyporzyczenia
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
        [Required]
        public DateTime? DataWyporzyczenia { get; set; }
        public DateTime? DataZwrotu { get; set; }
    }
}
