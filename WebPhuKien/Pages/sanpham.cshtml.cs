using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly SanPhamService _sanphamservice;
        public ProductsModel(SanPhamService sanPhamService)
        {
            _sanphamservice = sanPhamService;
        }
        public List<SanPham> SanPhams { get; set; }
        public async Task OnGet()
        {
            SanPhams = await _sanphamservice.GetSanPham();
        }
    }
}
