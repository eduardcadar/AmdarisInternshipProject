using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MicrobuzeContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<AgencyUser> AgencyUsers { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public MicrobuzeContext(DbContextOptions op) : base(op)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>()
                .HasIndex(a => a.AgencyName)
                .IsUnique();
            modelBuilder.Entity<Agency>()
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<AgencyUser>()
                .HasIndex(a => a.Username)
                .IsUnique();
            modelBuilder.Entity<AgencyUser>()
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<RegularUser>()
                .HasIndex(a => a.Username)
                .IsUnique();
            modelBuilder.Entity<RegularUser>()
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<Reservation>()
                .HasKey(res => new { res.TripId, res.RegularUserId });
        }
    }
}
