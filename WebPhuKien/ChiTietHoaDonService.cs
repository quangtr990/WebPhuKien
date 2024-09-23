using Microsoft.EntityFrameworkCore;
using WebPhuKien.Data;

namespace WebPhuKien
{
    public class ChiTietHoaDonService
    {
        AppDbContext _context;
        public ChiTietHoaDonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task ThemChiTiet(string _MaHD, string _MaSP, int _SoLuong, int _GiaTien)
        {

            var hoadon = await _context.ChiTietHoaDons.FirstOrDefaultAsync(x => x.MaHD == _MaHD
            && x.MaSP == _MaSP && x.SoLuong == _SoLuong && x.GiaTien == _GiaTien);
            if (hoadon == null)
            {
                _context.ChiTietHoaDons.Add(new ChiTietHoaDon
                {
                    MaHD = _MaHD,
                    MaSP=_MaSP,
                    SoLuong=_SoLuong,
                    GiaTien=_GiaTien
                });
            }
            else
            {
                throw new Exception("Chi tiet nay da ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task XoaChiTietHoaDon(string _MaHD, string _MaSP)
        {
            var chitiethoadonxoa = await _context.ChiTietHoaDons.FirstOrDefaultAsync(x => x.MaHD == _MaHD && x.MaSP == _MaSP);
            if (chitiethoadonxoa == null)
            {
                throw new Exception("Khong tim duoc hoa don can xoa!");
            }
            _context.ChiTietHoaDons.Remove(chitiethoadonxoa);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ChiTietHoaDon>> GetChiTietHoaDon()
        {
            return await _context.ChiTietHoaDons.Select(x => new ChiTietHoaDon
            {
                MaHD=x.MaHD,
                MaSP=x.MaSP,
                SoLuong=x.SoLuong,
                GiaTien=x.GiaTien
            }).ToListAsync();
        }
        public async Task UpdateChiTiet(string _MaHD, string _MaSP, int _SoLuong, int _GiaTien)
        {

            var updatect = await _context.ChiTietHoaDons.FirstOrDefaultAsync(x => x.MaHD == _MaHD
            && x.MaSP == _MaSP && x.SoLuong == _SoLuong && x.GiaTien == _GiaTien);
            if (updatect != null)
            {
                updatect.MaHD = _MaHD;
                updatect.MaSP = _MaSP;
                updatect.SoLuong = _SoLuong;
                updatect.GiaTien = _GiaTien;
            }
            else
            {
                throw new Exception("Chi tiet nay khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
    }
}
