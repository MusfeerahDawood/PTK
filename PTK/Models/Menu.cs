using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTK.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Logo { get; set; }
        

        //Pizzas
        public List<Pizza> Pizzas { get; set; }
    }
}
