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
        [Required(ErrorMessage = "Podaj tytuł filmu")][Display(Name = "Tytuł")]
        public string Name { get; set; }
        public Gatunek Gatunek { get; set; }
        [Required(ErrorMessage = "Wybierz gatunek filmu")]
        public int GatunekId { get; set; }
        [Required(ErrorMessage = "Podaj datę wydania")][Display(Name = "Data wydania")] public DateTime DataWydania { get; set; }
        [Required(ErrorMessage = "Podaj datę dodania do katalogu")][Display(Name = "Data dodania")] public DateTime DataDodaniaDoKatalogu { get; set; }
        [Display(Name = "Ilość kopii")] public int IloscDostepnychKopi { get; set; }
        [Display(Name="Ilość kopii w bazie")] public int IloscKopi { get; set; }
    }


}
