
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Search_Cluster.Models;

namespace Search_Cluster.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<CrawlingStrategy> CrawlingStrategies { get; set; }

        public DbSet<UrlCrawlingStrategy>UrlCrawlingStrategies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<CrawlingStrategy>().HasData(
                new CrawlingStrategy { CrawlingStrategyId = "pdf", CrawlingStrategyName = "pdf" },
                new CrawlingStrategy { CrawlingStrategyId = "docx", CrawlingStrategyName = "docx" },
                new CrawlingStrategy { CrawlingStrategyId = "html", CrawlingStrategyName = "html" },
                new CrawlingStrategy { CrawlingStrategyId = "txt", CrawlingStrategyName = "txt" }
);
        }
    }
}
