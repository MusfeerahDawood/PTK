using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PTK.Models
{
    public class ChefofPizza
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Pizzas")]
        public int PizzaId { get; set; }
        public  Pizza Pizzas { get; set; }

        [ForeignKey("Chef")]
        public int ChefId { get; set; }
        public   Chef Chef { get; set; }

    }
}
