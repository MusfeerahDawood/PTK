using System.ComponentModel.DataAnnotations;

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
       
    }
}
