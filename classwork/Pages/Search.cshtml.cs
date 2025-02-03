using classwork.Data;
using classwork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace classwork.Pages
{
    [AllowAnonymous]
    public class SearchModel : PageModel
    {
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public bool Submitted { get; set; }
        public IEnumerable<Game> Games { get; set; }

        private readonly GameService service;

        public SearchModel(GameService gameService)
        {
            service = gameService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Submitted = true;

            if (!string.IsNullOrEmpty(Title))
            {
                Games = await service.GetByTitle(Title);
            }

            if (!string.IsNullOrEmpty(Studio))
            {
                Games = await service.GetByStudio(Studio);
            }

            if (!string.IsNullOrEmpty(Genre))
            {
                Games = await service.GetByGenre(Genre);
            }

            if (Year > 0)
            {
                Games = await service.GetByReleaseYear(Year);
            }

            return Page();
        }
    }
}
