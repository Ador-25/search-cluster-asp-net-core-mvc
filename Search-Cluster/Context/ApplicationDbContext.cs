

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Search_Cluster.Models;
using System.Reflection.Emit;

namespace Search_Cluster.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Url>Urls { get; set; }
        public DbSet<CrawlingStrategy> CrawlingStrategies { get; set; }

        public DbSet<UrlCrawlingStrategy> UrlCrawlingStrategies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UrlCrawlingStrategy>()
    .HasKey(ucs => new { ucs.UrlId, ucs.CrawlingStrategyId });

            modelBuilder.Entity<UrlCrawlingStrategy>()
                .HasOne(ucs => ucs.Url)
                .WithMany(u => u.UrlCrawlingStrategies)
                .HasForeignKey(ucs => ucs.UrlId);

            modelBuilder.Entity<UrlCrawlingStrategy>()
                .HasOne(ucs => ucs.CrawlingStrategy)
                .WithMany(cs => cs.UrlCrawlingStrategies)
                .HasForeignKey(ucs => ucs.CrawlingStrategyId);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}