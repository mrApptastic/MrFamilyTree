using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace FamilyTreeAPI.Auth
{
    public class BranchRequirement : IAuthorizationRequirement
    {
        public BranchRequirement()
        {
        }
    }

    public class BranchRequirementHandler : AuthorizationHandler<BranchRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BranchRequirement requirement)
        {
            // Get the required branch id from the route data or other means
            var branchIdFromContext = context.Resource as string; // You may need to cast context.Resource to the correct type
            if (branchIdFromContext == null || !Guid.TryParse(branchIdFromContext, out var requiredBranchId))
            {
                return Task.CompletedTask;
            }

            if (!context.User.HasClaim(c => c.Type == "branch"))
            {
                return Task.CompletedTask;
            }

            var userBranchClaim = context.User.FindFirst(c => c.Type == "branch").Value;

            if (Guid.TryParse(userBranchClaim, out var userBranchId) && userBranchId == requiredBranchId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}