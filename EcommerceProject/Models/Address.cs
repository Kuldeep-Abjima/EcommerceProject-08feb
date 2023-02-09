﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Country { get; set; }

    }
}
