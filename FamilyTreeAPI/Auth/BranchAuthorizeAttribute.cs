using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FamilyTreeAPI.Auth
{
    public class BranchAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly Guid _branchId;

        public BranchAuthorizeAttribute(string branchId)
        {
            if (!Guid.TryParse(branchId, out _branchId))
            {
                throw new ArgumentException("Invalid GUID format", nameof(branchId));
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<IAuthorizationService>();
            var result = authService.AuthorizeAsync(context.HttpContext.User, _branchId.ToString(), "BranchPolicy").Result;

            if (!result.Succeeded)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

