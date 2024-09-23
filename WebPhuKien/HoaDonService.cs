using Microsoft.EntityFrameworkCore;
using WebPhuKien.Data;

namespace WebPhuKien
{
    public class HoaDonService
    {
        AppDbContext _context;
        public HoaDonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task XoaHoaDon(string _MaHD)
        {
            // Cập nhật trạng thái của khách hàng khi tìm thấy CCCD cần xóa
            var deletehd = await _context.HoaDons.FirstOrDefaultAsync(x => x.MaHD == _MaHD);
            if (deletehd != null)
            {
                deletehd.DaXoaHD = 1; // Cập nhật trạng thái của khách hàng
            }
            else
            {
                throw new Exception("Hoa don khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task ThemHoaDon(string _MaHD, string _CCCD, string _NgayDat)
        {
            var hoadon = await _context.HoaDons.FirstOrDefaultAsync(x => x.MaHD == _MaHD
            && x.CCCD == _CCCD && x.NgayDatHang == _NgayDat);
            if (hoadon == null)
            {
                _context.HoaDons.Add(new HoaDon
                {
                    MaHD= _MaHD,
                    CCCD= _CCCD,
                    NgayDatHang= _NgayDat,
                    DaXoaHD=0
                });
            }
            else
            {
                throw new Exception("Hoa don da ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<HoaDon>> GetHoaDon()
        {
            return await _context.HoaDons.Select(x => new HoaDon
            {
                MaHD= x.MaHD,
                CCCD= x.CCCD,
                NgayDatHang= x.NgayDatHang
            }).Where(x => x.DaXoaHD == 0).ToListAsync();
        }
        public async Task UpdateHoaDon(string _MaHD, string _CCCD, string _NgayDat)
        {
            var updatehd = await _context.HoaDons.FirstOrDefaultAsync(x => x.MaHD == _MaHD
            && x.CCCD == _CCCD && x.NgayDatHang == _NgayDat);
            if (updatehd != null)
            {
                updatehd.MaHD= _MaHD;
                updatehd.CCCD= _CCCD;
                updatehd.NgayDatHang = _NgayDat;
            }
            else
            {
                throw new Exception("Hoa don khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
    }
}
