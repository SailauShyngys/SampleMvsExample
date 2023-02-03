using Microsoft.EntityFrameworkCore;
using SampleMvsExample.Models;

namespace SampleMvsExample.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
        { 
        
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Issue> Issuess { get; set; }
        public DbSet<TimeTracking> TimeTracking { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priorities> Prioritiess { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SHYNPHARM\\MSSQLSERVER01;Initial Catalog=issue-tracking-db;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TimeTracking>()
                .HasOne(o => o.Issue)
                .WithMany(m => m.TimeTrackings)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
