using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("PizzaChef")]
        public int ChefID { get; set; }

        public virtual Chef PizzaChef { get; set; }
       

    }
}
