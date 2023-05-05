using Blazor_Automated_Email_Marketing_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Automated_Email_Marketing_System.dbContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; } = null!;
        public DbSet<Campaign> Campaigns { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Segment> SubscriberSegments { get; set; } = null!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database\database.db");
        }
    }
}