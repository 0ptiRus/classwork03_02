using classwork.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace classwork.Authorization
{
    public class IsGameOwnerHandler : AuthorizationHandler<IsGameOwnerRequirement, Game>
    {
        private readonly UserManager<IdentityUser> user_manager;

        public IsGameOwnerHandler(UserManager<IdentityUser> user_manager)
        {
            this.user_manager = user_manager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsGameOwnerRequirement requirement, Game resource)
        {
            var user = await user_manager.GetUserAsync(context.User);
            if (user == null)
            {
                return;
            }

            if(resource.UserId.Equals(user.Id))
            {
                context.Succeed(requirement);
            }
        }
    }
}
