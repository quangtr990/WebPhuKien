using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPhuKien.Data;

namespace WebPhuKien.Pages
{
    public class ListAccountModel : PageModel
    {
        private readonly AccountService _accountsevice;
        public ListAccountModel(AccountService accountService)
        {
            _accountsevice = accountService;
        }
        public List<DangNhap> lstAccount { get; set; }
        public async Task OnGet()
        {
            lstAccount = await _accountsevice.GetDangNhap();
        }
    }
}
