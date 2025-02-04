using classwork.Data;
using classwork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace classwork.Pages;

[Authorize("IsAuthenticated")]
public class IndexModel : PageModel
{
    private readonly GameService service;

    public IList<Game> Games { get; private set; }
    public IndexModel(GameService service)
    {
        this.service = service;
    }

    public async void OnGet()
    {
        Games = await service.GetAll();

        if(Games.Count == 0)
        {
            await service.FillDb();
            Page();
        }
    }

    public async Task<IActionResult> OnGetDeleteAsync(string title)
    {
        Game game = await service.GetOneByTitle(title);

        if (game != null)
        {
            await service.Remove(game);
        }

        return RedirectToPage();
    }
}
