using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.Campaign;
using RolePlayHelper.BLL.Services;
using System.Security.Claims;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        public CampaignController(CampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] CampaignFormDto form)
        {
            int gmId = int.Parse(User.FindFirstValue(ClaimTypes.Sid)!);

            _campaignService.Create(form.ToCampaign(), gmId);

            return Created();
        }
    }
}
