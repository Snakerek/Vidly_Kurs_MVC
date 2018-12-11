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
        [Required][Display(Name = "Tytuł")]
        public string Name { get; set; }
        public Gatunek Gatunek { get; set; }
        [Required]
        public int GatunekId { get; set; }
        [Required][Display(Name = "Data wydania")] public DateTime DataWydania { get; set; }
        [Required][Display(Name = "Data dodania")] public DateTime DataDodaniaDoKatalogu { get; set; }
        [Required][Display(Name = "Ilość kopii")] public int IloscDostepnychKopi { get; set; }
    }


}
