using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [Table("ThanhToan")]
    public class ThanhToan
    {
        [Key]
        public string MaThanhToan {  get; set; }
        public string MaHD { get; set; }
        public string  NgayThanhToan{ get; set; }
        public int SoTien {  get; set; }
        public string LoaiThanhToan { get; set; }
        public ThanhToan()
        {

        }
    }
}
