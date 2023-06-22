using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages.User
{
    [Authorize(Roles = "User")]
    public class FinalizacaoReservaModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
