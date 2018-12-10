using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nazwa użytkownika")]
        public string Name{ get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Typ subskrypcji")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Data Urodzenia")]
        public DateTime? BirthdayDate { get; set; }

    }
}
