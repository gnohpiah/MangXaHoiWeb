using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MangXaHoiWeb.Models;

public partial class QlmangXhContext : DbContext
{
    public QlmangXhContext()
    {
    }

    public QlmangXhContext(DbContextOptions<QlmangXhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<ChiaSe> ChiaSes { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<Thich> Thiches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-EO49JNSH\\SQLEXPRESS;Initial Catalog=QLMangXH;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.HasKey(e => e.MaBaiViet).HasName("PK__BaiViet__AEDD56479159E1A4");

            entity.ToTable("BaiViet");

            entity.Property(e => e.MaBaiViet)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Anh).IsUnicode(false);
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianDangBai).HasColumnType("date");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaiViet__Anh__4BAC3F29");
        });

        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.HasKey(e => e.MaBinhLuan).HasName("PK__BinhLuan__87CB66A0A187B562");

            entity.ToTable("BinhLuan");

            entity.Property(e => e.MaBinhLuan)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.MaBaiViet)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(254)
                .IsUnicode(false);

            entity.HasOne(d => d.MaBaiVietNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.MaBaiViet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BinhLuan__MaBaiV__534D60F1");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BinhLuan__MaBaiV__52593CB8");
        });

        modelBuilder.Entity<ChiaSe>(entity =>
        {
            entity.HasKey(e => e.MaChiaSe).HasName("PK__ChiaSe__54AE718F6E7BC321");

            entity.ToTable("ChiaSe");

            entity.Property(e => e.MaChiaSe)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.CheDoChiaSe).HasMaxLength(50);
            entity.Property(e => e.MaBaiViet)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.NgayChiaSe).HasColumnType("date");

            entity.HasOne(d => d.MaBaiVietNavigation).WithMany(p => p.ChiaSes)
                .HasForeignKey(d => d.MaBaiViet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiaSe__MaBaiVie__571DF1D5");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.ChiaSes)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiaSe__MaBaiVie__5629CD9C");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D762CBCD784E");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.AnhDaiDien).IsUnicode(false);
            entity.Property(e => e.CongViec).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HocVan).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Quote).HasMaxLength(50);
            entity.Property(e => e.TenNguoiDung).HasMaxLength(50);
        });

        modelBuilder.Entity<Thich>(entity =>
        {
            entity.HasKey(e => e.MaThich).HasName("PK__Thich__985232E753D525A4");

            entity.ToTable("Thich");

            entity.Property(e => e.MaThich)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.MaBaiViet)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(254)
                .IsUnicode(false);

            entity.HasOne(d => d.MaBaiVietNavigation).WithMany(p => p.Thiches)
                .HasForeignKey(d => d.MaBaiViet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thich__MaBaiViet__4F7CD00D");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.Thiches)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thich__MaBaiViet__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
