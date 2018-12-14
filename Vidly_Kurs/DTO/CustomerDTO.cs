using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vidly_Kurs.Models;

namespace Vidly_Kurs.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        [Min18YIfMember]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthdayDate { get; set; }
    }
}
