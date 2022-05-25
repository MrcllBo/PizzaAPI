using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data.Entities;

namespace PizzaAPI.Data
{
    public class PizzaContext: DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        { }

        public DbSet<Pizza> Pizza => Set<Pizza>();
        public DbSet<Topping> Topping => Set<Topping>();
        public DbSet<Sauce> Sauce => Set<Sauce>();

    }
}
