using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPhuKien.Data
{
    [Table("DangNhap")]
    public class DangNhap
    {
        [Key]
        public string Username {  get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public DangNhap() 
        { 
        
        }
    }
}
