﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesterin.Core.Entities
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Description { get; set; }
        
    }
}
