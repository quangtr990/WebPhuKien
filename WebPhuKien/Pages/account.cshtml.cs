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
            // Th?c hi?n ki?m tra th�ng tin ??ng nh?p ? ?�y
            // N?u ??ng nh?p th�nh c�ng, c� th? chuy?n h??ng ??n trang ch�nh
            // N?u ??ng nh?p th?t b?i, c� th? hi?n th? th�ng b�o l?i
            return RedirectToPage("/Index");
        }

        // POST: Th�m t�i kho?n m?i
        public async Task<IActionResult> OnPostRegisterAsync(string username, string password, string email)
        {
            try
            {
                await _accountService.ThemTaiKhoan(username, password, email);
                // Th�m t�i kho?n th�nh c�ng, c� th? chuy?n h??ng ho?c hi?n th? th�ng b�o
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // X? l� l?i khi th�m t�i kho?n
                ModelState.AddModelError(string.Empty, $"Loi: {ex.Message}");
                return Page();
            }
        }
    }
}