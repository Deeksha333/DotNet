﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Model
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="CoverType")]
        public string  Name { get; set; }
    }   
}