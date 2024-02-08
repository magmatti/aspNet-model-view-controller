using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedRentedCar
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any rented cars.
                if (context.RentedCar.Any())
                {
                    return;   // DB has been seeded
                }

                var clients = context.Clients.ToList();
                var cars = context.Car.ToList();

                context.RentedCar.AddRange(
                    new RentedCar
                    {
                        ClientID = clients.FirstOrDefault(c => c.Name == "Jan" && c.Surrname == "Kowalski").ClientID,
                        CarID = cars.FirstOrDefault(car => car.Model == "Camry" && car.YearOfProduction == 2022).CarID,
                        RentDate = DateTime.Parse("2022-01-15"),
                        ReturnDate = DateTime.Parse("2022-01-18"),
                        Cost = 300.00M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

