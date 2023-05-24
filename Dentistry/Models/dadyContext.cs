using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dentistry.Models
{
    public partial class dadyContext : DbContext
    {
        public dadyContext()
        {
        }

        public dadyContext(DbContextOptions<dadyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrato> Administratos { get; set; } = null!;
        public virtual DbSet<Check> Checks { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServicesFromCheck> ServicesFromChecks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server = 127.0.0.1;User = root;DataBase=dady");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrato>(entity =>
            {
                entity.ToTable("administratos");

                entity.HasIndex(e => e.Login, "login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio");

                entity.Property(e => e.Login)
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Check>(entity =>
            {
                entity.ToTable("checks");

                entity.HasIndex(e => e.IdRecord, "id_recordFK_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdRecord).HasColumnName("id_record");

                entity.Property(e => e.Price)
                    .HasMaxLength(255)
                    .HasColumnName("price");

                entity.HasOne(d => d.IdRecordNavigation)
                    .WithMany(p => p.Checks)
                    .HasForeignKey(d => d.IdRecord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_recordFK");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .HasMaxLength(45)
                    .HasColumnName("fio");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(45)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctors");

                entity.HasIndex(e => e.Fio, "name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Education)
                    .HasMaxLength(45)
                    .HasColumnName("education");

                entity.Property(e => e.Fio).HasColumnName("fio");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(45)
                    .HasColumnName("job_title");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("records");

                entity.HasIndex(e => e.IdAdministrator, "id_adminFK_idx");

                entity.HasIndex(e => e.IdClient, "id_clientFK_idx");

                entity.HasIndex(e => e.IdDoctor, "id_doctorFK_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Complaint)
                    .HasMaxLength(45)
                    .HasColumnName("complaint");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdAdministrator).HasColumnName("id_administrator");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

                entity.Property(e => e.RecordingTime)
                    .HasMaxLength(255)
                    .HasColumnName("recording_time");

                entity.HasOne(d => d.IdAdministratorNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdAdministrator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_adminFK");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_clientFK");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_doctorFK");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasIndex(e => e.Id, "idshops_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasMaxLength(255)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<ServicesFromCheck>(entity =>
            {
                entity.ToTable("services_from_checks");

                entity.HasIndex(e => e.IdCheck, "check_id_idx");

                entity.HasIndex(e => e.IdService, "service_idFK_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCheck).HasColumnName("id_check");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.Price)
                    .HasMaxLength(255)
                    .HasColumnName("price");

                entity.HasOne(d => d.IdCheckNavigation)
                    .WithMany(p => p.ServicesFromChecks)
                    .HasForeignKey(d => d.IdCheck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("check_idFK");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.ServicesFromChecks)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("service_idFK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
