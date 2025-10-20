using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.CharClass;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharClassController : ControllerBase
    {
        private readonly CharClassService _charClassService;
        public CharClassController(CharClassService charClassService)
        {
            _charClassService = charClassService;
        }

        [HttpGet]
        public ActionResult<List<Character>> GetAll()
        {
            List<CharClassListDto> characters = _charClassService.getAll().Select(c => c.ToCharClassListDto()).Where(c=>c.ParentClass == null).ToList();
            return Ok(characters);
        }

        [HttpPost("Add-Class")]
        public ActionResult Add([FromBody] CharClassFormDto form)
        {
            _charClassService.Add(form.ToCharClass());
            return Created();
        }
    }
}
