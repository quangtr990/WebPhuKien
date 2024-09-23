using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [PrimaryKey("MaHD", "MaSP"),Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        public string MaHD { get; set; }
        public string MaSP { get; set;}
        public int SoLuong {  get; set; }
        public int GiaTien {  get; set; }
        public ChiTietHoaDon()
        {

        }
    }
}
