using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class xoaaccountModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly KhachHangService _khachhangservice;
        public xoaaccountModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public BindingModel Input { get; set; }
        public DangNhap dangnhap { get; set; }
        public void OnGet(string? username)
        {
            if (username == null)
            {
                Response.Redirect("/danhsachtaikhoan");
                return;
            }

            var user = _context.DangNhaps.Find(username);
            if (user == null)
            {
                Response.Redirect("/danhsachtaikhoan");
                return;
            }

            Input = new BindingModel
            {
                Username = username,
                Pass = user.Pass,
                Email = user.Email,
            };

            dangnhap = user;
        }
        public void OnPost(string? username)
        {
            if (username == null)
            {
                Response.Redirect("/danhsachtaikhoan");
                return;
            }
            var deleteuser = _context.DangNhaps.FirstOrDefault(x => x.Username == username);
            if (deleteuser == null)
            {
                Response.Redirect("/danhsachtaikhoan");
                return;
            }
            _context.DangNhaps.Remove(deleteuser);
            _context.SaveChangesAsync();
            Response.Redirect("/danhsachtaikhoan");
            return;
        }

        public class BindingModel
        {
            public string Username { get; set; }
            public string Pass { get; set; }
            public string Email { get; set; }
        }
    }
}
