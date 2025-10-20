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
        public ActionResult<List<Character>> GetAll()
        {
            List<CharacterListDto> characters = _characterService.getAll().Select(c => c.ToCharacterListDto()).ToList();
            return Ok(characters);
        }

        [HttpPost("Add-Character")]
        public ActionResult Add([FromBody] CharacterFormDto form)
        {

            // PROBLEM: we are transforming charaktform containing list of ClassIds to Character containing list of Classes.
            // To be able to map these correctly we need the form.
            // This means we need the form in our service? Not the tranformed Character??

            _characterService.Add(form.ToCharacter());
            return Created();
        }

    }
}
