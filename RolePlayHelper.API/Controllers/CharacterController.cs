using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.Character;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DL.Entities;

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
        [Authorize]
        public ActionResult<List<Character>> GetAll()
        {
            List<CharacterListDto> characters = _characterService.getAll().Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        [HttpPost("Add-Character")]
        [Authorize]
        public ActionResult Add([FromBody] CharacterFormDto form)
        {
            _characterService.Add(form.ToCharacter());
            return Created();
        }

    }
}
