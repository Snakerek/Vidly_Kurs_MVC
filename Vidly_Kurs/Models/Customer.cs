using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Vidly_Kurs.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [StringLength(255)]
        [Display(Name = "Nazwa użytkownika")]
        public string Name{ get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Typ subskrypcji")]
            [Min18YIfMember]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Data Urodzenia")]
        public DateTime? BirthdayDate { get; set; }

    }
}
