using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public string MaLoai {  get; set; }
        public string TenLoai {  get; set; }
        public int DaXoaLSP {  get; set; }
        public LoaiSanPham() { }
    }
}
