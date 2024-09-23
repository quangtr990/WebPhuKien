using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace WebPhuKien.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<DangNhap>DangNhaps { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<LoaiSanPham>LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ThanhToan>ThanhToans { get; set; }
    }
}
