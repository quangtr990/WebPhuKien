using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class capnhatsanphamModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly SanPhamService _sanphamservice;
        public capnhatsanphamModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public BindingModel Input { get; set; }
        public SanPham SanPham { get; set; }
        public void OnGet(string? masp)
        {
            if (masp == null)
            {
                Response.Redirect("/danhsachsanpham");
                return;
            }

            var sp = _context.SanPhams.Find(masp);
            if (sp == null)
            {
                Response.Redirect("/danhsachsanpham");
                return;
            }

            Input = new BindingModel
            {
                MaSP = masp,
                TenSP = sp.TenSP,
                MaLoai=sp.MaLoai,
                GiaBan = sp.GiaBan,
                SoLuongTonKho = sp.SoLuongTonKho,
                Color = sp.Color,
                Size = sp.Size,
                Gender = sp.Gender,
                HinhAnh = sp.HinhAnh
            };

            SanPham = sp;
        }
        public  void OnPost(string? masp)
        {
            if (masp == null)
            {
                Response.Redirect("/danhsachsanpham");
                return;
            }
            var updatesp = _context.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (updatesp != null)
            {
                updatesp.TenSP = Input.TenSP;
                updatesp.GiaBan = Input.GiaBan;
                updatesp.SoLuongTonKho = Input.SoLuongTonKho;
                updatesp.Color = Input.Color;
                updatesp.Size = Input.Size;
                updatesp.Gender = Input.Gender;
                updatesp.HinhAnh = Input.HinhAnh;
            }
            else
            {
                Response.Redirect("/danhsachsanpham");
                return;
            }
            _context.SaveChanges();
            Response.Redirect("/danhsachsanpham");
            return;
        }

        public class BindingModel
        {
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