using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NEXUS.Models
{
    public partial class NEXUSContext : DbContext
    {
        public NEXUSContext()
        {
        }

        public NEXUSContext(DbContextOptions<NEXUSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BroadbandConnection> BroadbandConnections { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DialUpConnection> DialUpConnections { get; set; } = null!;
        public virtual DbSet<LandLineConnection> LandLineConnections { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BroadbandConnection>(entity =>
            {
                entity.HasKey(e => e.ConnectionId)
                    .HasName("PK__Broadban__404A64F3EBE37789");

                entity.ToTable("BroadbandConnection");

                entity.Property(e => e.ConnectionId).HasColumnName("ConnectionID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PakageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AddressDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DialUpConnection>(entity =>
            {
                entity.HasKey(e => e.ConnectionId)
                    .HasName("PK__DialUpCo__404A64F39455C7A2");

                entity.ToTable("DialUpConnection");

                entity.Property(e => e.ConnectionId).HasColumnName("ConnectionID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PakageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LandLineConnection>(entity =>
            {
                entity.HasKey(e => e.ConnectionId)
                    .HasName("PK__LandLine__404A64F35A4913A5");

                entity.ToTable("LandLineConnection");

                entity.Property(e => e.ConnectionId).HasColumnName("ConnectionID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PakageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration");

                entity.Property(e => e.Email).HasMaxLength(1);

                entity.Property(e => e.Password).HasMaxLength(1);

                entity.Property(e => e.UserName).HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
