using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace classwork.Pages
{
    [Authorize("IsAuthenticated")]
    public class StatisticsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
