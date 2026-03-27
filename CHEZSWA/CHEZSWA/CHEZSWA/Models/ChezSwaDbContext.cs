using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
namespace CHEZSWA.Models
{
    public class ChezSwaDbContext : DbContext
    {


        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }

        public ChezSwaDbContext(DbContextOptions<ChezSwaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Menu>()
                .Property(m => m.Id)
                .ValueGeneratedNever();

          
            modelBuilder.Entity<Gerecht>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Gerecht>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Gerechten)
                .WithOne(g => g.Menu)
                .HasForeignKey(g => g.MenuId);


            modelBuilder.Entity<Menu>().HasData(
              new Menu { Id = "ONT", Naam = "Ontbijtmenu" },
              new Menu { Id = "LUNCH", Naam = "Lunchmenu" },
              new Menu { Id = "SUGG", Naam = "Suggestiemenu" }
          );

            modelBuilder.Entity<Gerecht>().HasData(
    new Gerecht { Id = 1, Naam = "Croissant", Prijs = 2.50m, IsVeggie = true, MenuId = "ONT" },
    new Gerecht { Id = 2, Naam = "Omelet", Prijs = 4.00m, IsVeggie = false, MenuId = "ONT" },

    new Gerecht { Id = 3, Naam = "Tomatensoep", Prijs = 5.50m, IsVeggie = true, MenuId = "LUNCH" },
    new Gerecht { Id = 4, Naam = "Broodje kip", Prijs = 6.50m, IsVeggie = false, MenuId = "LUNCH" },

    new Gerecht { Id = 5, Naam = "Steak", Prijs = 18.00m, IsVeggie = false, MenuId = "SUGG" },
    new Gerecht { Id = 6, Naam = "Gegrilde groenten", Prijs = 12.00m, IsVeggie = true, MenuId = "SUGG" }
);

        }
    }
}


