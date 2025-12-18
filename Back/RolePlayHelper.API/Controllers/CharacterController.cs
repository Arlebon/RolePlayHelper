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
        [Authorize(Roles = "Admin")]

        public ActionResult<List<CharacterListDto>> GetAll()
        {
            List<CharacterListDto> characters = _characterService.GetAll().Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        [HttpGet("/api/characters/public")]
        
        public ActionResult<List<CharacterPublicListDto>> GetAllPublic()
        {
            List<CharacterPublicListDto> characters = _characterService.GetAllPublic().Select(c => c.ToCharacterPublicListDto()).ToList();
            return Ok(characters);
        }

        [HttpGet ("/api/characters/{userId}")]
        [Authorize]
        public ActionResult<List<CharacterListDto>> GetAllByUserId([FromRoute] int userId)
        {
            List<CharacterListDto> characters = _characterService.GetAllByUserId(userId).Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        [Authorize]
        [HttpGet("List-Characters")]
        public ActionResult<List<CharacterListDto>> ListCharactersByUser()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid)!);
            List<CharacterListDto> characters = _characterService.GetAllByUserId(userId).Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        [HttpPost("Add-Character")]
        [Authorize]
        public ActionResult Add([FromBody] CharacterFormDto form)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid)!);
            _characterService.Add(userId, form.ToCharacter());
            return Created();
        }

        [HttpPatch("{id}/Change-Visibility")]
        public ActionResult ChangeVisibility([FromRoute] int id,[FromBody] CharacterVisibilityFormDto form)
        {
            _characterService.UpdateVisibilty(id, form.IsPublic);
            return Ok();
        }


        // TO DO LIST GLOBALE (NOM CHAR, RASSE, PROPRIETAIRE ETC)

    }
}
