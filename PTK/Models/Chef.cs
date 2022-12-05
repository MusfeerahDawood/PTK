using System.ComponentModel.DataAnnotations;

namespace PTK.Models
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
