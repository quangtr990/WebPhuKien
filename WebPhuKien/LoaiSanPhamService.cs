using Microsoft.EntityFrameworkCore;
using WebPhuKien.Data;

namespace WebPhuKien
{
    public class LoaiSanPhamService
    {
        AppDbContext _context { get; set; }
        public LoaiSanPhamService(AppDbContext context) { _context = context; }
        public async Task<List<LoaiSanPham>> GetLoaiSanPham()
        {
            return await _context.LoaiSanPhams
                .Where(x => x.DaXoaLSP == 0)
                .Select(x => new LoaiSanPham
            {
                MaLoai=x.MaLoai,
                TenLoai=x.TenLoai
            }).ToListAsync();
        }
        public async Task ThemLoaiSanPham(string _MaLSP, string _TenLSP)
        {

            var loaisanpham = await _context.LoaiSanPhams.FirstOrDefaultAsync(x => x.MaLoai == _MaLSP && x.TenLoai==_TenLSP);
            if (loaisanpham == null)
            {
                _context.LoaiSanPhams.Add(new LoaiSanPham
                {
                    MaLoai=_MaLSP,
                    TenLoai=_TenLSP,
                    DaXoaLSP = 0
                });
            }
            else
            {
                throw new Exception("Loai san pham da ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task XoaLoaiSanPham(string _MaLoai)
        {
            // Cập nhật trạng thái của khách hàng khi tìm thấy CCCD cần xóa
            var deletelsp = await _context.LoaiSanPhams.FirstOrDefaultAsync(x => x.MaLoai == _MaLoai);
            if (deletelsp != null)
            {
                deletelsp.DaXoaLSP = 1; // Cập nhật trạng thái của khách hàng
            }
            else
            {
                throw new Exception("Loai san pham khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLoaiSanPham(string _MaLSP, string _TenLSP)
        {

            var updatelsp = await _context.LoaiSanPhams.FirstOrDefaultAsync(x => x.MaLoai == _MaLSP && x.TenLoai==_TenLSP);
            if (updatelsp != null)
            {
                updatelsp.MaLoai= _MaLSP;
                updatelsp.TenLoai= _TenLSP;
            }
            else
            {
                throw new Exception("Loai san pham khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
    }
}
