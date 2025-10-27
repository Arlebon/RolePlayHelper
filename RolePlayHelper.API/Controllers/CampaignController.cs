using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.Campaign;
using RolePlayHelper.API.Models.Character;
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

        [HttpPost("{campaignId}/Enter-Campaign")]
        [Authorize]
        public ActionResult EnterCampaign([FromRoute]int campaignId, [FromBody] CampaignSubscriptionFormDto form)
        {

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid)!);

            _campaignService.AddCharacterToCampaign(userId, campaignId, form.CharacterId);

            return NoContent();
        }

        [HttpGet("{id}/Characters")]
        public ActionResult GetCharactersByCampaign([FromRoute] int id)
        {
            List<CharacterByCampaignListDto> characters = _campaignService.GetCharactersByCampaign(id).Select(c => c.ToCharacterByCampaignListDto()).ToList();

            return Ok(characters);
        }

        [HttpPut("{campaignId}/ChangeGM/{userId}")]
        [Authorize(Policy = "IsGM")]
        public ActionResult ChangeGM([FromRoute] int campaignId, [FromRoute] int userId)
        {
            _campaignService.ChangeGM(campaignId, userId);

            return Ok();
        }
    }

}
