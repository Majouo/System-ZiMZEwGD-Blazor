using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System_ZiMZEwGD_Blazor.Data;

namespace System_ZiMZEwGD_Blazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<System_ZiMZEwGD_Blazor.Data.Consumption>? Consumption { get; set; }
        public DbSet<System_ZiMZEwGD_Blazor.Data.Monitor>? Monitor { get; set; }
    }
}