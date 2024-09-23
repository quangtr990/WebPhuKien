using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string CCCD {  get; set; }
        public string HoVaTen {  get; set; }
        public string Email {  get; set; }
        public string Phone {  get; set; }
        public string DiaChi { get; set; }
        public int DaXoaKH {  get; set; }
        public KhachHang() { }
    }
}
