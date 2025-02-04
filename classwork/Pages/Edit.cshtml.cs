using classwork.Data;
using classwork.Models;
using classwork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static classwork.Models.GameModel;

namespace classwork.Pages
{
    [Authorize("IsAuthenticated")]
    public class EditModel : PageModel
    {
        private readonly GameService service;

        [BindProperty]
        public UpdateGameModel Game {  get; set; }

        public EditModel(GameService service)
        {
            this.service = service;
        }

        public async void OnGetAsync(int id)
        {
            Game game_entity = await service.GetById(id);
            Game = new(game_entity.Title, game_entity.Studio, game_entity.Genre, game_entity.ReleaseDate, game_entity.SalesCount, id, game_entity.UserId);

            if(Game == null)
            {
                NotFound();
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await service.Update(GameModelExtension.ToGameWithId(Game.Id, Game.UserId, Game));
            return RedirectToPage("./Index");
        }
    }
}
