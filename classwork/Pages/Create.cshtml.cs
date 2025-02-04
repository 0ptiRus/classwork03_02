using classwork.Data;
using classwork.Models;
using classwork.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static classwork.Models.GameModel;

namespace classwork.Pages
{
    [Authorize("IsAuthenticated")]
    public class CreateModel : PageModel
    {
        private readonly GameService service;
        private readonly UserManager<IdentityUser> user_manager;

        public CreateModel(GameService service, UserManager<IdentityUser> user_manager)
        {
            this.service = service;
            this.user_manager = user_manager;
        }

        [BindProperty]
        public GameModel Game { get; set; }

        public async void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                IdentityUser? user = await user_manager.GetUserAsync(User);
                Game game = GameModelExtension.ToGame(user.Id, Game);
                await service.Create(game);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToPage("./Index");
        }
    }
}
