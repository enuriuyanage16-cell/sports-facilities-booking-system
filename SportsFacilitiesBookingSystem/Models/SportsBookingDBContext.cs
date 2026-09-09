using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportsFacilitiesBookingSystem.Models;

public partial class SportsBookingDBContext : DbContext
{
    public SportsBookingDBContext()
    {
    }

    public SportsBookingDBContext(DbContextOptions<SportsBookingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Inquiry> Inquiries { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SportsBookingDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("Amenity_PK");

            entity.ToTable("Amenity");

            entity.Property(e => e.AmenityId)
                .ValueGeneratedNever()
                .HasColumnName("AmenityID");
            entity.Property(e => e.AmenityName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("Booking_PK");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.FacilityFacilityId).HasColumnName("Facility_FacilityID");
            entity.Property(e => e.MemberMemberId).HasColumnName("Member_MemberID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilityFacility).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FacilityFacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Booking_Facility_FK");

            entity.HasOne(d => d.MemberMember).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MemberMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Booking_Member_FK");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("Facility_PK");

            entity.ToTable("Facility");

            entity.Property(e => e.FacilityId)
                .ValueGeneratedNever()
                .HasColumnName("FacilityID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FacilityAvailabilityStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FacilityLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FacilityName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FacilityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusReason)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.AmenityAmenities).WithMany(p => p.FacilityFacilities)
                .UsingEntity<Dictionary<string, object>>(
                    "FacilityAmenity",
                    r => r.HasOne<Amenity>().WithMany()
                        .HasForeignKey("AmenityAmenityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FacilityAmenity_Amenity_FK"),
                    l => l.HasOne<Facility>().WithMany()
                        .HasForeignKey("FacilityFacilityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FacilityAmenity_Facility_FK"),
                    j =>
                    {
                        j.HasKey("FacilityFacilityId", "AmenityAmenityId").HasName("FacilityAmenity_PK");
                        j.ToTable("FacilityAmenity");
                        j.IndexerProperty<int>("FacilityFacilityId").HasColumnName("Facility_FacilityID");
                        j.IndexerProperty<int>("AmenityAmenityId").HasColumnName("Amenity_AmenityID");
                    });

            entity.HasMany(d => d.SportSports).WithMany(p => p.FacilityFacilities)
                .UsingEntity<Dictionary<string, object>>(
                    "FacilitySport",
                    r => r.HasOne<Sport>().WithMany()
                        .HasForeignKey("SportSportId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FacilitySport_Sport_FK"),
                    l => l.HasOne<Facility>().WithMany()
                        .HasForeignKey("FacilityFacilityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FacilitySport_Facility_FK"),
                    j =>
                    {
                        j.HasKey("FacilityFacilityId", "SportSportId").HasName("FacilitySport_PK");
                        j.ToTable("FacilitySport");
                        j.IndexerProperty<int>("FacilityFacilityId").HasColumnName("Facility_FacilityID");
                        j.IndexerProperty<int>("SportSportId").HasColumnName("Sport_SportID");
                    });
        });

        modelBuilder.Entity<Inquiry>(entity =>
        {
            entity.HasKey(e => e.InquiryId).HasName("Inquiry_PK");

            entity.ToTable("Inquiry");

            entity.Property(e => e.InquiryId)
                .ValueGeneratedNever()
                .HasColumnName("InquiryID");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FacilityFacilityId).HasColumnName("Facility_FacilityID");
            entity.Property(e => e.InquiryMessage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilityFacility).WithMany(p => p.Inquiries)
                .HasForeignKey(d => d.FacilityFacilityId)
                .HasConstraintName("Inquiry_Facility_FK");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("Member_PK");

            entity.ToTable("Member");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.MemberAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MemberEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MemberName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MemberPassword)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MemberPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasMany(d => d.SportSports).WithMany(p => p.MemberMembers)
                .UsingEntity<Dictionary<string, object>>(
                    "MemberSport",
                    r => r.HasOne<Sport>().WithMany()
                        .HasForeignKey("SportSportId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("MemberSports_Sport_FK"),
                    l => l.HasOne<Member>().WithMany()
                        .HasForeignKey("MemberMemberId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("MemberSports_Member_FK"),
                    j =>
                    {
                        j.HasKey("MemberMemberId", "SportSportId").HasName("MemberSports_PK");
                        j.ToTable("MemberSports");
                        j.IndexerProperty<int>("MemberMemberId").HasColumnName("Member_MemberID");
                        j.IndexerProperty<int>("SportSportId").HasColumnName("Sport_SportID");
                    });
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("Payment_PK");

            entity.ToTable("Payment");

            entity.HasIndex(e => e.BookingBookingId, "Payment__IDX").IsUnique();

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BookingBookingId).HasColumnName("Booking_BookingID");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BookingBooking).WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.BookingBookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Booking_FK");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("Review_PK");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("ReviewID");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FacilityFacilityId).HasColumnName("Facility_FacilityID");
            entity.Property(e => e.MemberMemberId).HasColumnName("Member_MemberID");

            entity.HasOne(d => d.FacilityFacility).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.FacilityFacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Facility_FK");

            entity.HasOne(d => d.MemberMember).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MemberMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Review_Member_FK");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("Sport_PK");

            entity.ToTable("Sport");

            entity.Property(e => e.SportId)
                .ValueGeneratedNever()
                .HasColumnName("SportID");
            entity.Property(e => e.SportName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
