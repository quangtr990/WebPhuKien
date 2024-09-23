using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPhuKien.Data;

namespace WebPhuKien
{
    public class AccountService
    {
        AppDbContext _context;
        public AccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task XoaUser(string _Usrer)
        {
            var userxoa = await _context.DangNhaps.FirstOrDefaultAsync(x => x.Username == _Usrer);
            if (userxoa == null)
            {
                throw new Exception("Khong tim thay user");
            }
            _context.DangNhaps.Remove(userxoa);
            await _context.SaveChangesAsync();
        }
        public async Task ThemTaiKhoan(string _Username, string _Pass, string _Email)
        {
            var user = await _context.DangNhaps.FirstOrDefaultAsync(x => x.Username == _Username
            && x.Pass == _Pass && x.Email == _Email);
            if (user == null)
            {
                _context.DangNhaps.Add(new DangNhap
                {
                    Username = _Username,
                    Pass = _Pass,
                    Email = _Email
                });
            }
            else
            {
                throw new Exception("User da ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<DangNhap>> GetDangNhap()
        {
            return await _context.DangNhaps.ToListAsync();
        }
        public async Task UpdateTaiKhoan(string _Username, string _Pass, string _Email)
        {
            var updateuser = await _context.DangNhaps.FirstOrDefaultAsync(x => x.Username == _Username
            && x.Pass == _Pass && x.Email == _Email);
            if (updateuser != null)
            {
                updateuser.Username = _Username;
                updateuser.Pass = _Pass;
                updateuser.Email = _Email;
            }
            else
            {
                throw new Exception("User khong ton tai!");
            }
            await _context.SaveChangesAsync();
        }
        public async Task<bool> KiemTraTaiKhoan(string _Username, string _Pass)
        {
            var user = await _context.DangNhaps.FirstOrDefaultAsync(x => x.Username == _Username && x.Pass == _Pass);
            if (user != null)
            {
                // Trả về true nếu tìm thấy tài khoản
                return true;
            }
            else
            {
                // Nếu không tìm thấy tài khoản, ném ngoại lệ
                throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác");
            }
        }
    }
}
