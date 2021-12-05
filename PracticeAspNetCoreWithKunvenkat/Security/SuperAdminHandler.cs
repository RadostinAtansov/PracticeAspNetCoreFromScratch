namespace PracticeAspNetCoreWithKunvenkat.Security
{

    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;

    public class SuperAdminHandler : AuthorizationHandler<ManageAdminRoleAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRoleAndClaimsRequirement requirement)
        {
            if (context.User.IsInRole("Super Admin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
