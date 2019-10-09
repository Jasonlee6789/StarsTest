using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasketballCompetition.Models
{
    public partial class CompetitionDBContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Enrolment> Enrolment { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }


        public CompetitionDBContext(DbContextOptions<CompetitionDBContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Enrolment>(entity =>
            {
                entity.HasKey(e => e.EnrolId);

                entity.Property(e => e.GradeId).HasMaxLength(20);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Enrolment)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_CourseEnrol");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Enrolment)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_StdEnrol");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeGrade)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.Phone).HasMaxLength(30);

                entity.Property(e => e.TeamName).HasMaxLength(30);
            });
        }
    }
}
