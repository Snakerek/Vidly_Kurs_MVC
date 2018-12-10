using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class Gatunek
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}
