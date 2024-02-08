using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedCarMake
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.

            if (context.CarMake.Any())
            {
                return;
            }

            context.CarMake.AddRange(
                new CarMake
                {
                    MakeName = "Toyota"
                },
                new CarMake
                {
                    MakeName = "Ford"
                },
                new CarMake
                {
                    MakeName = "Chevrolet"
                },
                new CarMake
                {
                    MakeName = "Honda"
                },
                new CarMake
                {
                    MakeName = "Volkswagen"
                }
            );

            context.SaveChanges();
        }
    }
}
