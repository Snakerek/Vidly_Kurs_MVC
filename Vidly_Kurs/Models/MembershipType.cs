﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly_Kurs.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte OplataNaZadanie = 1;
    }
}
