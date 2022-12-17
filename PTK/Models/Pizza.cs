using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PTK.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public int Price { get; set; }

        [ForeignKey("Menus")]
        public int MenuId { get; set; }

        public virtual Menu Menus { get; set; }

        //Chef
        public List<Chef> Chefs { get; set; }
       

    }
}
