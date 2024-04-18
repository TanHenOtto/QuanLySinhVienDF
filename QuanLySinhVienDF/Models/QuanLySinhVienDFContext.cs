using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLySinhVienDF.Models
{
    public partial class QuanLySinhVienDFContext : DbContext
    {
        public QuanLySinhVienDFContext()
        {
        }

        public QuanLySinhVienDFContext(DbContextOptions<QuanLySinhVienDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Khoa> Khoas { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-00RR3EAA\\SQLEXPRESS;Initial Catalog=QuanLySinhVienDF;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.ToTable("Khoa");

                entity.Property(e => e.KhoaId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.ToTable("Lop");

                entity.Property(e => e.LopId).ValueGeneratedNever();

                entity.HasOne(d => d.Khoa)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.KhoaId)
                    .HasConstraintName("FK__Lop__KhoaId__38996AB5");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.ToTable("SinhVien");

                entity.Property(e => e.SinhVienId).ValueGeneratedNever();

                entity.HasOne(d => d.Lop)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.LopId)
                    .HasConstraintName("FK__SinhVien__LopId__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
