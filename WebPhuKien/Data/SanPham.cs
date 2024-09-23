using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public string MaSP {  get; set; }
        public string TenSP { get; set; }
        public string MaLoai {  get; set; }
        public int GiaBan {  get; set; }
        public int SoLuongTonKho {  get; set; }
        public string Color {  get; set; }
        public string Size {  get; set; }
        public string Gender {  get; set; }
        public string HinhAnh { get; set; }
        public int DaXoaSP {  get; set; }
        public SanPham() { }
    }
}
