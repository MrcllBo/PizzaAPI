using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Data.Entities
{
    public class Dough
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public bool IsGlutenFree { get; set; }

    }
}
