using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_Kurs.Models;

namespace Vidly_Kurs.ViewModels
{
    public class MoviesFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Gatunek> Gatunek { get; set; }
    }
}
