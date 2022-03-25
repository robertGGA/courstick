﻿using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class SubType
    {
        [Key]
        public int SubTypeId { get; set; }
        public string Criterion { get; set; }
        public List<Course> Courses { get; set; } 
    }
}
