using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.Character;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DL.Entities;
using System.Security.Claims;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;
        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<List<Character>> GetAll()
        {
            List<CharacterListDto> characters = _characterService.GetAll().Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        [HttpPost("Add-Character")]
        //[Authorize]
        public ActionResult Add([FromBody] CharacterFormDto form)
        {

            _characterService.Add(form.UserId, form.ToCharacter());
            return Created();
        }

        [HttpPatch("{id}/Change-Visibility")]
        public ActionResult ChangeVisibility([FromRoute] int id,[FromBody] CharacterVisibilityFormDto form)
        {
            _characterService.UpdateVisibilty(id, form.IsPublic);
            return Ok();
        }

        [Authorize]
        [HttpGet("List-Characters")]
        public ActionResult<List<CharacterListDto>> ListCharactersByUser()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid)!);
            List<CharacterListDto> characters = _characterService.GetAllByUserId(userId).Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        // TO DO LIST GLOBALE (NOM CHAR, RASSE, PROPRIETAIRE ETC)

    }
}
