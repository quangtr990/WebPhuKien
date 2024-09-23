using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using WebPhuKien.Data;

namespace WebPhuKien
{
    public class KhachHangService
    {
        AppDbContext _context {  get; set; }
        public KhachHangService(AppDbContext context)
        {
            _context = context;
        }
        public async Task ThemKhachHang(string _CCCD, string _HoTen, string _Phone, string _Email, string _DiaChi)
        {

            var khachhang = await _context.KhachHangs.FirstOrDefaultAsync(x => x.CCCD == _CCCD 
            && x.HoVaTen == _HoTen && x.Phone == _Phone && x.Email==_Email&& x.DiaChi==_DiaChi);
            if (khachhang == null)
            {
                _context.KhachHangs.Add(new KhachHang
                {
                    CCCD = _CCCD,
                    HoVaTen = _HoTen,
                    Phone = _Phone,
                    Email = _Email,
                    DiaChi=_DiaChi,
                    DaXoaKH = 0
                });
            }
            else
            {
                throw new Exception("Khach hang da ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task XoaKhachHang(string _CCCD)
        {
            // Cập nhật trạng thái của khách hàng khi tìm thấy CCCD cần xóa
            var detelekh = await _context.KhachHangs.FirstOrDefaultAsync(x => x.CCCD == _CCCD);
            if (detelekh != null)
            {
                detelekh.DaXoaKH = 1; // Cập nhật trạng thái của khách hàng
            }
            else
            {
                throw new Exception("Khach hang khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<KhachHang>> GetKhachHang()
        {
            return await _context.KhachHangs
                .Where(x => x.DaXoaKH == 0)
                .Select(x => new KhachHang
                {
                    CCCD = x.CCCD,
                    HoVaTen= x.HoVaTen,
                    Phone = x.Phone,
                    Email = x.Email,
                    DiaChi = x.DiaChi
                }).ToListAsync();
        }
        public async Task UpdateKhachHang(string _CCCD, string _HoTen, string _Phone, string _Email, string _DiaChi)
        {

            var updatekh = await _context.KhachHangs.FirstOrDefaultAsync(x => x.CCCD == _CCCD
            && x.HoVaTen == _HoTen && x.Phone == _Phone && x.Email == _Email && x.DiaChi == _DiaChi);
            if (updatekh != null)
            {
                updatekh.CCCD = _CCCD;
                updatekh.HoVaTen = _HoTen;
                updatekh.Phone = _Phone;
                updatekh.Email = _Email;
                updatekh.DiaChi = _DiaChi;
            }
            else
            {
                throw new Exception("Khach hang khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
    }
}
