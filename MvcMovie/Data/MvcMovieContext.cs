using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.carMake)
                .WithMany()
                .HasForeignKey(c => c.MakeID);
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;
        public DbSet<MvcMovie.Models.Clients> Clients { get; set; } = default!;
        public DbSet<MvcMovie.Models.Car> Car { get; set; } = default!;
        public DbSet<MvcMovie.Models.CarMake> CarMake { get; set; } = default!;
        public DbSet<MvcMovie.Models.RentedCar> RentedCar { get; set; } = default!;
    }
}
