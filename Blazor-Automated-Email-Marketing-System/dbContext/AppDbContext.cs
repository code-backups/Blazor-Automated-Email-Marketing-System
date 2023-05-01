using Blazor_Automated_Email_Marketing_System.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Blazor_Automated_Email_Marketing_System.dbContext
{
        public class AppDbContext : DbContext
        {
                protected internal DbSet<Subscriber> Subscribers { get; set; } = null!;
                protected internal DbSet<Segment> Segments { get; set; } = null!;
                protected internal DbSet<Campaign> Campaigns { get; set; } = null!;

                protected internal DbSet<SubscriberSegment> SubscriberSegments { get; set; } = null!;
                protected internal DbSet<CampaignSegment> CampaignSegments { get; set; } = null!;

                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                        raw.SetProvider(new SQLite3Provider_e_sqlite3());
                        optionsBuilder.UseSqlite(@"Data Source=Data\database.db");
                }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.Entity<CampaignSegment>()
                                .HasKey(cs => new { cs.CampaignId, cs.SegmentId });

                        modelBuilder.Entity<SubscriberSegment>()
                                .HasKey(ss => new { ss.SubscriberId, ss.SegmentId });
                }

        }
}
