using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;

#nullable disable

namespace RatingSystem.Data
{
    public partial class ConferenceDatabaseContext : DbContext
    {
        public ConferenceDatabaseContext()
        {
        }

        public ConferenceDatabaseContext(DbContextOptions<ConferenceDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConferenceXrating> ConferenceXratings { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ConferenceDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConferenceXrating>(entity =>
            {
                entity.ToTable("ConferenceXrating");

                entity.Property(e => e.RatingValue).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("UserEmail")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
