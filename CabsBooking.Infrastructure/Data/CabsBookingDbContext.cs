using System;
using CabsBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CabsBooking.Infrastructure.Data
{
    public class CabsBookingDbContext:DbContext
    {
        public CabsBookingDbContext(DbContextOptions<CabsBookingDbContext> options) : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistories { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(ConfigureBookings);
            modelBuilder.Entity<BookingsHistory>(ConfigureBookingsHistory);
            modelBuilder.Entity<CabType>(ConfigureCabType);
            modelBuilder.Entity<Place>(ConfigurePlace);

        }

        private void ConfigureBookings(EntityTypeBuilder<Booking> modelBuilder)
        {
            modelBuilder.ToTable("Bookings");
            modelBuilder.HasKey(b => b.Id);
            modelBuilder.Property(b => b.Email);
            modelBuilder.Property(b => b.BookingTime);
            modelBuilder.Property(b => b.ToPlace);
            modelBuilder.Property(b => b.PickUpAddress);
            modelBuilder.Property(b => b.LandMark);
            modelBuilder.Property(b => b.PickupDate);
            modelBuilder.Property(b => b.PickupTime);
            modelBuilder.HasOne(b => b.CabType).WithMany(b => b.Bookings).HasForeignKey(b => b.FromPlace);
            modelBuilder.HasOne(b => b.CabType).WithMany(b => b.Bookings).HasForeignKey(b => b.CabTypeId);
            modelBuilder.Property(b => b.ContactNo);
            modelBuilder.Property(b => b.Status);


        }
        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistory> modelBuilder)
        {
            modelBuilder.ToTable("BookingsHistory");
            modelBuilder.HasKey(b => b.Id);
            modelBuilder.Property(b => b.Email);
            modelBuilder.Property(b => b.BookingTime);
            modelBuilder.Property(b => b.ToPlace);
            modelBuilder.Property(b => b.PickUpAddress);
            modelBuilder.Property(b => b.LandMark);
            modelBuilder.Property(b => b.PickupDate);
            modelBuilder.Property(b => b.PickupTime);
            modelBuilder.HasOne(b => b.CabType).WithMany(b => b.BookingsHistories).HasForeignKey(b => b.FromPlace);
            modelBuilder.HasOne(b => b.CabType).WithMany(b => b.BookingsHistories).HasForeignKey(b => b.CabTypeId);
            modelBuilder.Property(b => b.ContactNo);
            modelBuilder.Property(b => b.Status);
            modelBuilder.Property(b => b.comp_time);
            modelBuilder.Property(b => b.charge);
            modelBuilder.Property(b => b.Feedback);

        }

        private void ConfigureCabType(EntityTypeBuilder<CabType> modelBuilder)
        {
            modelBuilder.ToTable("CabTypes");
            modelBuilder.HasKey(c => c.CabTypeId);
            modelBuilder.Property(c => c.CabTypeName);
        }

        private void ConfigurePlace(EntityTypeBuilder<Place> modelBuilder)
        {
            modelBuilder.ToTable("Places");
            modelBuilder.HasKey(p => p.PlaceId);
            modelBuilder.Property(p => p.PlaceName);
        }

    }
}
