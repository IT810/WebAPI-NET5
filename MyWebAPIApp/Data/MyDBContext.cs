using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<LoaiHangHoa> LoaiHangHoas { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

        // Sử dụng Fluent API để định nghĩa thuộc tính các bảng và mối quan hệ giữa các bảng.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang");
                entity.HasKey(e => e.MaDH);
                entity.Property(e => e.NgayDat).HasDefaultValueSql("getutcdate()");
                entity.Property(e => e.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(dh => new { dh.MaDH, dh.MaHH });
                entity.HasOne(e => e.DonHang).WithMany(e => e.ChiTietDonHangs).HasForeignKey(e => e.MaDH).HasConstraintName("FK_CHITIETDONHANG_DONHANG");

                entity.HasOne(e => e.HangHoa).WithMany(e => e.ChiTietDonHangs).HasForeignKey(e => e.MaHH).HasConstraintName("FK_CHITIETDONHANG_HANGHOA");

            });
        }
    }
}
