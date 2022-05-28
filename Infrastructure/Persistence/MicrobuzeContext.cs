using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MicrobuzeContext : DbContext
    {
        public DbSet<AgencyUser> AgencyUsers { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public MicrobuzeContext(DbContextOptions<MicrobuzeContext> op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgencyUser>()
                .HasIndex(a => a.Username)
                .IsUnique();
            modelBuilder.Entity<RegularUser>()
                .HasIndex(a => a.Username)
                .IsUnique();
            modelBuilder.Entity<Reservation>()
                .HasKey(res => new { res.TripId, res.RegularUserId });
        }
    }
}
