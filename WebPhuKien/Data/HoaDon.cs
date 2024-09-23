using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public string MaHD {  get; set; }
        public string CCCD { get; set;}
        public string NgayDatHang { get; set;}
        public int DaXoaHD {  get; set;}
        public HoaDon() { }
    }
}
