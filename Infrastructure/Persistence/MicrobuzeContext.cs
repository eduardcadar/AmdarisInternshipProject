using Infrastructure.Persistence.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

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
            modelBuilder.Entity<Reservation>().HasKey(res => new { res.TripId, res.RegularUserId });
        }
    }
}
