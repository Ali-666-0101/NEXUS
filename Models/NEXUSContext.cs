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

        public virtual DbSet<CallCharge> CallCharges { get; set; } = null!;
        public virtual DbSet<ConnectionPlan> ConnectionPlans { get; set; } = null!;
        public virtual DbSet<ConnectionType> ConnectionTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallCharge>(entity =>
            {
                entity.Property(e => e.CallChargeId).ValueGeneratedNever();

                entity.Property(e => e.CallType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Charge).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.CallCharges)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__CallCharg__PlanI__4E88ABD4");
            });

            modelBuilder.Entity<ConnectionPlan>(entity =>
            {
                entity.ToTable("ConnectionPlan");

                entity.Property(e => e.ConnectionPlanId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.ConnectionType)
                    .WithMany(p => p.ConnectionPlans)
                    .HasForeignKey(d => d.ConnectionTypeId)
                    .HasConstraintName("FK__Connectio__Conne__4BAC3F29");
            });

            modelBuilder.Entity<ConnectionType>(entity =>
            {
                entity.ToTable("ConnectionType");

                entity.Property(e => e.ConnectionTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address1).HasColumnName("Address_1");

                entity.Property(e => e.Address2).HasColumnName("Address_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
