using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System_ZiMZEwGD_Blazor.Data;

namespace System_ZiMZEwGD_Blazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Consumption>().HasData(
                new Consumption { type = "fdsfs", date = new DateTime(), value = 4 },
                new Consumption { type = "gdfgfd", date = new DateTime(), value = 5 }
                );


        }
        */
        public DbSet<System_ZiMZEwGD_Blazor.Data.Consumption>? Consumption { get; set; }
    }
}