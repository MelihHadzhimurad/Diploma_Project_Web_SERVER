using Microsoft.EntityFrameworkCore;
using Smart_Tire_app_Server.Models;

namespace Smart_Tire_app_Server.DataBaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<PaidFine> PaidFines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(index => index.UserName).IsUnique();
            modelBuilder.Entity<Fine>().HasIndex(index => index.UnlockCode).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
