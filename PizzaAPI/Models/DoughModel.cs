using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Models
{
    public class DoughModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public bool IsGlutenFree { get; set; }
    }
}
