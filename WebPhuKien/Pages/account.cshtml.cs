using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class accountModel : PageModel
    {
        private readonly AccountService _accountService;

        public accountModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Hi?n th? form ??ng nh?p
        public void OnGet()
        {
        }

        // POST: ??ng nh?p
        public async Task<IActionResult> OnPostLoginAsync(string username, string password)
        {
            // Th?c hi?n ki?m tra thông tin ??ng nh?p ? ?ây
            // N?u ??ng nh?p thành công, có th? chuy?n h??ng ??n trang chính
            // N?u ??ng nh?p th?t b?i, có th? hi?n th? thông báo l?i
            return RedirectToPage("/Index");
        }

        // POST: Thêm tài kho?n m?i
        public async Task<IActionResult> OnPostRegisterAsync(string username, string password, string email)
        {
            try
            {
                await _accountService.ThemTaiKhoan(username, password, email);
                // Thêm tài kho?n thành công, có th? chuy?n h??ng ho?c hi?n th? thông báo
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // X? lý l?i khi thêm tài kho?n
                ModelState.AddModelError(string.Empty, $"Loi: {ex.Message}");
                return Page();
            }
        }
    }
}