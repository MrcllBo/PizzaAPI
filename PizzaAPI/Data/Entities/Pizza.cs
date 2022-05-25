using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Data.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public Dough Dough { get; set; }

        public Sauce? Sauce { get; set; }

        public ICollection<Topping>? Toppings { get; set; }
    }
}
