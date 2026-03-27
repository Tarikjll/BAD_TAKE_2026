using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
namespace CHEZSWA.Models
{
    public class ChezSwaDbContext: DbContext
    {

        public ChezSwaDbContext(DbContextOptions<ChezSwaDbContext> options) : base(options)
        { 
        }
       public DbSet<Reservatie> Reservaties { get; set; }   

    }
}


