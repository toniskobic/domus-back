using System;
using domus.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace domus.Models
{
    public partial class domusContext : IdentityDbContext<ApplicationUser>
    {
        public domusContext(DbContextOptions<domusContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;

        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Dormitory> Dormitories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<AdType> AdTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=domusDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dormitory>()
            .HasMany(f => f.Users)
            .WithOne(x => x.Dormitory)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Participant>().HasKey(x => new { x.UserId, x.EventId });
            modelBuilder.Entity<Participant>()
              .HasOne(x => x.User)
              .WithMany(x => x.Participants)
              .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Participant>()
              .HasOne(x => x.Event)
              .WithMany(x => x.Participants)
              .HasForeignKey(x => x.EventId);
        }
    }
}
