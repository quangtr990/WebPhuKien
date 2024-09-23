using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class ListProductModel : PageModel
    {
        private readonly SanPhamService _sanphamservice;
        public ListProductModel(SanPhamService sanPhamService)
        {
            _sanphamservice = sanPhamService;
        }
        public List<SanPham> lstSanPham { get; set; }
        public async Task OnGet()
        {
            lstSanPham= await _sanphamservice.GetSanPham();
        }
    }
}
