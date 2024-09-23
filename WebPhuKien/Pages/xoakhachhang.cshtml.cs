using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class xoakhachhangModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly KhachHangService _khachhangservice;
        public xoakhachhangModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public BindingModel Input { get; set; }
        public KhachHang khachhang { get; set; }
        public void OnGet(string? cccd)
        {
            if (cccd == null)
            {
                Response.Redirect("/danhsachkhachhang");
                return;
            }

            var kh = _context.KhachHangs.Find(cccd);
            if (kh == null)
            {
                Response.Redirect("/danhsachkhachhang");
                return;
            }

            Input = new BindingModel
            {
                CCCD = cccd,
                HoTen = kh.HoVaTen,
                Email = kh.Email,
                Phone = kh.Phone,
                DiaChi = kh.DiaChi
            };

            khachhang = kh;
        }
        public void OnPost(string? cccd)
        {
            if (cccd == null)
            {
                Response.Redirect("/danhsachsanpham");
                return;
            }
            var deletekh = _context.KhachHangs.FirstOrDefault(x => x.CCCD == cccd);
            if (deletekh != null)
            {
                deletekh.DaXoaKH = 1;
            }
            else
            {
                Response.Redirect("/danhsachkhachhang");
                return;
            }
            _context.SaveChanges();
            Response.Redirect("/danhsachkhachhang");
            return;
        }

        public class BindingModel
        {
            public string CCCD { get; set; }
            public string HoTen { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string DiaChi { get; set; }
        }
    }
}

