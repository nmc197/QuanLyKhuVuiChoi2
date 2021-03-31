using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyKhuVuiChoi2.Models
{
    public partial class AmusementParkContext : DbContext
    {
        public AmusementParkContext()
        {
        }

        public AmusementParkContext(DbContextOptions<AmusementParkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Dichvu> Dichvus { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Khutrochoi> Khutrochois { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Phongban> Phongbans { get; set; }
        public virtual DbSet<Thietbi> Thietbis { get; set; }
        public virtual DbSet<Trochoi> Trochois { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MS29M6R;Database=AmusementPark;UID=sa;PWD=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(10)
                    .HasColumnName("MaHD")
                    .IsFixedLength(true);

                entity.Property(e => e.MaDv)
                    .HasMaxLength(10)
                    .HasColumnName("MaDV")
                    .IsFixedLength(true);

                entity.Property(e => e.SoLanSuDungDv)
                    .HasMaxLength(10)
                    .HasColumnName("SoLanSuDungDV")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaDvNavigation)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.MaDv)
                    .HasConstraintName("FK_CHITIETHOADON_DICHVU");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithOne(p => p.Chitiethoadon)
                    .HasForeignKey<Chitiethoadon>(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETHOADON_HOADON");
            });

            modelBuilder.Entity<Dichvu>(entity =>
            {
                entity.HasKey(e => e.MaDv);

                entity.ToTable("DICHVU");

                entity.Property(e => e.MaDv)
                    .HasMaxLength(10)
                    .HasColumnName("MaDV")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKhu)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenDv)
                    .HasMaxLength(50)
                    .HasColumnName("TenDV");

                entity.HasOne(d => d.MaKhuNavigation)
                    .WithMany(p => p.Dichvus)
                    .HasForeignKey(d => d.MaKhu)
                    .HasConstraintName("FK_DICHVU_KHUTROCHOI");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.ToTable("HOADON");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(10)
                    .HasColumnName("MaHD")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayHd)
                    .HasMaxLength(10)
                    .HasColumnName("NgayHD")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_HOADON_KHACHHANG");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.GioTinhKh)
                    .HasMaxLength(50)
                    .HasColumnName("GioTinhKH");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");

                entity.Property(e => e.TuoiKh).HasColumnName("TuoiKH");
            });

            modelBuilder.Entity<Khutrochoi>(entity =>
            {
                entity.HasKey(e => e.MaKhu);

                entity.ToTable("KHUTROCHOI");

                entity.Property(e => e.MaKhu)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaNvql)
                    .HasMaxLength(10)
                    .HasColumnName("MaNVQL")
                    .IsFixedLength(true);

                entity.Property(e => e.TenKhu).HasMaxLength(50);

                entity.HasOne(d => d.MaNvqlNavigation)
                    .WithMany(p => p.Khutrochois)
                    .HasForeignKey(d => d.MaNvql)
                    .HasConstraintName("FK_KHUTROCHOI_NHANVIEN");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.MaKhuPhuTrach)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPb)
                    .HasMaxLength(10)
                    .HasColumnName("MaPB")
                    .IsFixedLength(true);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.QueQuan).HasMaxLength(50);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(50)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaKhuPhuTrachNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.MaKhuPhuTrach)
                    .HasConstraintName("FK_NHANVIEN_KHUTROCHOI1");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithOne(p => p.Nhanvien)
                    .HasForeignKey<Nhanvien>(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NHANVIEN_PHONGBAN1");
            });

            modelBuilder.Entity<Phongban>(entity =>
            {
                entity.HasKey(e => e.MaPb);

                entity.ToTable("PHONGBAN");

                entity.Property(e => e.MaPb)
                    .HasMaxLength(10)
                    .HasColumnName("MaPB")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaDiem).HasMaxLength(50);

                entity.Property(e => e.MaTp)
                    .HasMaxLength(10)
                    .HasColumnName("MaTP")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayNc)
                    .HasColumnType("date")
                    .HasColumnName("NgayNC");

                entity.Property(e => e.TenPb)
                    .HasMaxLength(50)
                    .HasColumnName("TenPB");

                entity.HasOne(d => d.MaTpNavigation)
                    .WithMany(p => p.Phongbans)
                    .HasForeignKey(d => d.MaTp)
                    .HasConstraintName("FK_PHONGBAN_NHANVIEN1");
            });

            modelBuilder.Entity<Thietbi>(entity =>
            {
                entity.HasKey(e => e.MaTb);

                entity.ToTable("THIETBI");

                entity.Property(e => e.MaTb)
                    .HasMaxLength(10)
                    .HasColumnName("MaTB")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTroChoi)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenTb)
                    .HasMaxLength(50)
                    .HasColumnName("TenTB");

                entity.Property(e => e.TinhTrang).HasMaxLength(50);

                entity.HasOne(d => d.MaTroChoiNavigation)
                    .WithMany(p => p.Thietbis)
                    .HasForeignKey(d => d.MaTroChoi)
                    .HasConstraintName("FK_THIETBI_TROCHOI");
            });

            modelBuilder.Entity<Trochoi>(entity =>
            {
                entity.HasKey(e => e.MaTroChoi);

                entity.ToTable("TROCHOI");

                entity.Property(e => e.MaTroChoi)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaKhu)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaNvphuTrach)
                    .HasMaxLength(10)
                    .HasColumnName("MaNVPhuTrach")
                    .IsFixedLength(true);

                entity.Property(e => e.TenTroChoi).HasMaxLength(50);

                entity.HasOne(d => d.MaKhuNavigation)
                    .WithMany(p => p.Trochois)
                    .HasForeignKey(d => d.MaKhu)
                    .HasConstraintName("FK_TROCHOI_KHUTROCHOI");

                entity.HasOne(d => d.MaNvphuTrachNavigation)
                    .WithMany(p => p.Trochois)
                    .HasForeignKey(d => d.MaNvphuTrach)
                    .HasConstraintName("FK_TROCHOI_NHANVIEN");
            });

            modelBuilder.Entity<Ve>(entity =>
            {
                entity.HasKey(e => e.MaVe);

                entity.ToTable("VE");

                entity.Property(e => e.MaVe)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(10)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKhu)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NgayPhatHanh)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_VE_KHACHHANG");

                entity.HasOne(d => d.MaKhuNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.MaKhu)
                    .HasConstraintName("FK_VE_KHUTROCHOI");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
