using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WesternInn_TG_SA_AF.Models;

namespace WesternInn_TG_SA_AF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WesternInn_TG_SA_AF.Models.Room> Room { get; set; }
    }
}