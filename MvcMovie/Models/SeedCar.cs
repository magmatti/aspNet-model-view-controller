using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedCar
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any cars.
                if (context.Car.Any())
                {
                    return;   // DB has been seeded
                }

                var carMakes = context.CarMake.ToList();

                context.Car.AddRange(
                    new Car
                    {
                        Model = "Camry",
                        YearOfProduction = 2022,
                        PriceForDay = 750,
                        carMake = carMakes.FirstOrDefault(c => c.MakeName == "Toyota")
                    },
                    new Car
                    {
                        Model = "F-150",
                        YearOfProduction = 2022,
                        PriceForDay = 1200,
                        carMake = carMakes.FirstOrDefault(c => c.MakeName == "Ford")
                    },
                    new Car
                    {
                        Model = "Civic",
                        YearOfProduction = 2022,
                        PriceForDay = 400,
                        carMake = carMakes.FirstOrDefault(c => c.MakeName == "Honda")
                    },
                    new Car
                    {
                        Model = "Silverado",
                        YearOfProduction = 2022,
                        PriceForDay = 300,
                        carMake = carMakes.FirstOrDefault(c => c.MakeName == "Chevrolet")
                    },
                    new Car
                    {
                        Model = "Golf",
                        YearOfProduction = 2022,
                        PriceForDay = 200,
                        carMake = carMakes.FirstOrDefault(c => c.MakeName == "Volkswagen")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
