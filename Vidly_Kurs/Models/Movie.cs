using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Gatunek Gatunek { get; set; }
        [Required]
        public int GatunekId { get; set; }
        [Required] public DateTime DataWydania { get; set; }
        [Required] public DateTime DataDodaniaDoKatalogu { get; set; }
        [Required] public int IloscDostepnychKopi { get; set; }
    }


}
