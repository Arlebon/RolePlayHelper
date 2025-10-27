using Microsoft.AspNetCore.Authorization;
using RolePlayHelper.BLL.Services;
using System.Security.Claims;

namespace RolePlayHelper.API.CustomAuthorize.IsGM
{
    public class IsGMHandler : AuthorizationHandler<IsGMRequirement>
    {
        private readonly CampaignService _campaignService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsGMHandler(CampaignService campaignService, IHttpContextAccessor httpContextAccessor)
        {
            _campaignService = campaignService;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsGMRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            int userId = int.Parse(context.User.FindFirstValue(ClaimTypes.Sid)!);

            httpContext!.Request.RouteValues.TryGetValue("campaignId", out var campaignIdObj);
            int campaignId = int.Parse(campaignIdObj!.ToString()!);

            if(_campaignService.IsGM(campaignId, userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
