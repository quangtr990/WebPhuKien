using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class addsanphamModel : PageModel
    {
        private readonly SanPhamService _sanphamservice;
        private readonly LoaiSanPhamService _loaisanphamservice;
        public addsanphamModel(SanPhamService sanphamService, LoaiSanPhamService loaisanphamservice)
        {
            _sanphamservice = sanphamService;
            _loaisanphamservice = loaisanphamservice;
        }
        public List<LoaiSanPham> LoaiSanPhams { get; set; }
        [BindProperty]
        public BindingModel Input { get; set; }
        public async Task OnGet()
        {
            LoaiSanPhams = await _loaisanphamservice.GetLoaiSanPham();
        }
        public async Task<IActionResult> OnPost()
        {
            await _sanphamservice.ThemSanPham(Input.MaSP, Input.TenSP, Input.MaLoai, Input.GiaBan, Input.SoLuongTonKho,Input.Color, Input.Size, Input.Gender, Input.HinhAnh);
            return RedirectToPage("danhsachsanpham");
        }
        public class BindingModel
        {
            [Required]
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public string MaLoai { get; set; }
            public int GiaBan { get; set; }
            public int SoLuongTonKho { get; set; }
            public string Color { get; set; }
            public string Size { get; set; }
            public string Gender { get; set; }
            public string HinhAnh { get; set; }
        }
    }
}
