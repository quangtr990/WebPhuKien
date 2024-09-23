using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Drawing;
using WebPhuKien.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace WebPhuKien
{
    public class SanPhamService
    {
        AppDbContext _context {  get; set; }
        public SanPhamService(AppDbContext context) {  _context = context; }
        public async Task <List<SanPham>>GetSanPham()
        {
            return await _context.SanPhams
            .Where(x => x.DaXoaSP == 0)
            .Select(x => new SanPham
            {
                MaSP = x.MaSP,
                TenSP = x.TenSP,
                MaLoai = x.MaLoai,
                GiaBan = x.GiaBan,
                SoLuongTonKho = x.SoLuongTonKho,
                Color = x.Color,
                Size = x.Size,
                Gender = x.Gender,
                HinhAnh = x.HinhAnh,
            }).ToListAsync();
        }
        public async Task ThemSanPham(string _MaSP, string _TenSP,string _MaLoai, int _GiaBan, int _SoLuongTonKho, string _Color, string _Size, string _Gender, string _HinhAnh)
        {

            var sanpham = await _context.SanPhams.FirstOrDefaultAsync(x => x.MaSP==_MaSP && x.TenSP==_TenSP&& x.MaLoai==_MaLoai
            && x.GiaBan==_GiaBan && x.SoLuongTonKho==_SoLuongTonKho && x.Color==_Color && x.Size==_Size&& x.Gender==_Gender);
            if (sanpham == null)
            {
                _context.SanPhams.Add(new SanPham
                {
                    MaSP= _MaSP,
                    TenSP= _TenSP,
                    MaLoai= _MaLoai,
                    GiaBan=_GiaBan,
                    SoLuongTonKho= _SoLuongTonKho,
                    Color= _Color,
                    Size= _Size,
                    Gender= _Gender,
                    HinhAnh=_HinhAnh,
                    DaXoaSP=0
                });
            }
            else
            {
                throw new Exception("San pham da ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task XoaSanPham(string _MaSP)
        {
            // Cập nhật trạng thái của khách hàng khi tìm thấy CCCD cần xóa
            var deletesp =  await _context.SanPhams.FirstOrDefaultAsync(x => x.MaSP == _MaSP);
            if (deletesp != null)
            {
                deletesp.DaXoaSP = 1; // Cập nhật trạng thái của khách hàng
            }
            else
            {
                throw new Exception("San pham khong ton tai!");
            }
             await _context.SaveChangesAsync();
        }
        public async Task UpdateSanPham(string _MaSP, string _TenSP, string _MaLoai, int _GiaBan, int _SoLuongTonKho, string _Color, string _Size, string _Gender, string _HinhAnh)
        {
            var updatesp = await _context.SanPhams.FirstOrDefaultAsync(x => x.MaSP == _MaSP);
            if (updatesp != null)
            {
                updatesp.TenSP = _TenSP;
                updatesp.GiaBan = _GiaBan;
                updatesp.SoLuongTonKho = _SoLuongTonKho;
                updatesp.Color = _Color;
                updatesp.Size = _Size;
                updatesp.HinhAnh= _HinhAnh;
                updatesp.Gender = _Gender;
            }
            else
            {
                throw new Exception("San pham khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
    }
}
