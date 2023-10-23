using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BTL_WEB.Models
{
    public partial class SQLBanKinhMat1Context : DbContext
    {
        public SQLBanKinhMat1Context()
        {
        }

        public SQLBanKinhMat1Context(DbContextOptions<SQLBanKinhMat1Context> options)
            : base(options)
        {
        }
        
        public virtual DbSet<TChatLieu> TChatLieus { get; set; } = null!;
        public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; } = null!;
        public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; } = null!;
        public virtual DbSet<THangSx> THangSxes { get; set; } = null!;
        public virtual DbSet<THoaDonBan> THoaDonBans { get; set; } = null!;
        public virtual DbSet<TLoaiSp> TLoaiSps { get; set; } = null!;
        public virtual DbSet<TMauSac> TMauSacs { get; set; } = null!;
        public virtual DbSet<TQuocGia> TQuocGia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-6IJHPHQ6\\SQLEXPRESS;Initial Catalog=SQLBanKinhMat1;User ID=sa;Password=bach2duong;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TChatLieu>(entity =>
            {
                entity.HasKey(e => e.MaChatLieu);

                entity.ToTable("tChatLieu");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChatLieu).HasMaxLength(150);
            });

            modelBuilder.Entity<TChiTietHdb>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaSp });

                entity.ToTable("tChiTietHDB");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength();

                entity.Property(e => e.DonGiaBan).HasColumnType("money");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.TChiTietHdbs)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.TChiTietHdbs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tChiTietHDB_tDanhMucSP");
            });

            modelBuilder.Entity<TDanhMucSp>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("tDanhMucSP");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.GioiThieuSp)
                    .HasMaxLength(500)
                    .HasColumnName("GioiThieuSP");

                entity.Property(e => e.MaChatLieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaHangSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaHangSX")
                    .IsFixedLength();

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNuocSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaNuocSX")
                    .IsFixedLength();

                entity.Property(e => e.Slton).HasColumnName("SLTon");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(150)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaChatLieuNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaChatLieu)
                    .HasConstraintName("FK_tDanhMucSP_tChatLieu");

                entity.HasOne(d => d.MaHangSxNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaHangSx)
                    .HasConstraintName("FK_tDanhMucSP_tHangSX");

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK_tDanhMucSP_tLoaiSP");

                entity.HasOne(d => d.MaMauSacNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaMauSac)
                    .HasConstraintName("FK_tDanhMucSP_tMauSac");

                entity.HasOne(d => d.MaNuocSxNavigation)
                    .WithMany(p => p.TDanhMucSps)
                    .HasForeignKey(d => d.MaNuocSx)
                    .HasConstraintName("FK_tDanhMucSP_tQuocGia");
            });

            modelBuilder.Entity<THangSx>(entity =>
            {
                entity.HasKey(e => e.MaHangSx);

                entity.ToTable("tHangSX");

                entity.Property(e => e.MaHangSx)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MaHangSX")
                    .IsFixedLength();

                entity.Property(e => e.HangSx)
                    .HasMaxLength(100)
                    .HasColumnName("HangSX");

                entity.Property(e => e.MaNuocThuongHieu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<THoaDonBan>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("tHoaDonBan");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSoThue)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");

                entity.Property(e => e.ThongTinThue).HasMaxLength(250);

                entity.Property(e => e.TongTienHd)
                    .HasColumnType("money")
                    .HasColumnName("TongTienHD");
            });

            modelBuilder.Entity<TLoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("tLoaiSP");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Loai).HasMaxLength(100);
            });

            modelBuilder.Entity<TMauSac>(entity =>
            {
                entity.HasKey(e => e.MaMauSac);

                entity.ToTable("tMauSac");

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenMauSac).HasMaxLength(100);
            });

            modelBuilder.Entity<TQuocGia>(entity =>
            {
                entity.HasKey(e => e.MaNuoc);

                entity.ToTable("tQuocGia");

                entity.Property(e => e.MaNuoc)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNuoc).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
