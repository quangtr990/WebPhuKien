using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class ListKhachHangModel : PageModel
    {
        private readonly KhachHangService _khachhangsevice;
        public ListKhachHangModel(KhachHangService khachhangsevice)
        {
            _khachhangsevice = khachhangsevice;
        }
        public List<KhachHang> lstKhachHang { get; set; }
        public async Task OnGet()
        {
            lstKhachHang = await _khachhangsevice.GetKhachHang();
        }
    }
}
