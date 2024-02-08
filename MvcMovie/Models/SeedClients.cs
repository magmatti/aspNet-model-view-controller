using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedClients
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.

            if (context.Clients.Any())
            {
                return;
            }

            context.Clients.AddRange(
                new Clients
                {
                    Name = "Jan",
                    Surrname = "Kowalski",
                    Email = "jan.kowalski@example.com",
                    Telefon = 690690690
                },
                    new Clients
                    {
                        Name = "Anna",
                        Surrname = "Nowak",
                        Email = "anna.nowak@example.com",
                        Telefon = 601601601
                    },
                    new Clients
                    {
                        Name = "Piotr",
                        Surrname = "Wójcik",
                        Email = "piotr.wojcik@example.com",
                        Telefon = 505505505
                    },
                    new Clients
                    {
                        Name = "Katarzyna",
                        Surrname = "Wozniak",
                        Email = "katarzyna.wozniak@example.com",
                        Telefon = 777777777
                    },
                    new Clients
                    {
                        Name = "Marek",
                        Surrname = "Lis",
                        Email = "marek.lis@example.com",
                        Telefon = 123123123
                    }
            );

            context.SaveChanges();
        }
    }
}
