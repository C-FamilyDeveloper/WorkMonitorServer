using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection.Emit;
using WorkMonitorServer.Models.DataEntities;

namespace WorkMonitorServer.Models.DataContexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Screen> Screens { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<AcceptedApp> AcceptedApps { get; set; } = null!;
        public DbSet<AcceptedSite> AcceptedSites { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
