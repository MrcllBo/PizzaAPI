using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PizzaAPI.Data.Entities;

namespace PizzaAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PizzaContext(serviceProvider.GetRequiredService<DbContextOptions<PizzaContext>>()))
            {
                if (!context.Dough.Any())
                {
                    context.Dough.AddRange(
                        new Dough
                        {
                            Name = "Normale",
                            IsGlutenFree = false
                        },
                        new Dough
                        {
                            Name = "Farro",
                            IsGlutenFree = false
                        },
                        new Dough
                        {
                            Name = "Senza Glutine",
                            IsGlutenFree = true
                        }
                        );
                }

                if (!context.Sauce.Any())
                {
                    context.Sauce.AddRange(
                        new Sauce
                        {
                            Name = "Pomodoro",
                            IsVegan = true
                        },
                        new Sauce
                        {
                            Name = "Marinara",
                            IsVegan = true
                        },
                        new Sauce
                        {
                            Name = "Bianca",
                            IsVegan = false
                        },
                        new Sauce
                        {
                            Name = "Pesto",
                            IsVegan = true
                        }
                        );
                }

                if (!context.Topping.Any())
                {
                    context.Topping.AddRange(
                        new Topping { Name = "Mozzarella" },
                        new Topping { Name = "Mozzarella di Bufala" },
                        new Topping { Name = "Salsiccia" },
                        new Topping { Name = "Funghi" },
                        new Topping { Name = "Olive" },
                        new Topping { Name = "Carciofi" },
                        new Topping { Name = "Prosciutto" }
                        );
                }

                context.SaveChanges();
            }
        }
    }
}
