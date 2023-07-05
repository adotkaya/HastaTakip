using HastaTakip.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaTakip.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        
        }

        public DbSet<Hasta> hastalar { get; set; }
        public DbSet<Ziyaret> ziyaretler { get; set; }
    }
}
