using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Data.Entities
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required] //errore se facciamo un inserimento se valore è nullo, non si può creare pizze che non hanno nome
        [MaxLength(100)]
        public string? Name { get; set; }

        public Sauce? Sauce { get; set; } //relazione che ci può essere,ma potrebbe no

        public ICollection<Topping>? Toppings { get; set; } //relazione molti a molti, n a n
    }
}
