using classwork.Data;
using classwork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace classwork.Pages;

[AllowAnonymous]
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
    }
}
