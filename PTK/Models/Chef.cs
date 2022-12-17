﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTK.Models
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Nationaliy { get; set; }
      

        //Pizzas
        public List<Pizza> Pizzas { get; set; }
    }
}
