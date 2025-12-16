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
        public ActionResult<List<CharClassListDto>> GetAll()
        {
            List<CharClassListDto> characters = _charClassService
                .getAll()
                .Select(c => c.ToCharClassListDto())
                .Where(c=>c.ParentClass == null) //Je ne veux pas reafficher les subclasses après les parent classes. Mais dans Parentclasses
                .ToList();

            return Ok(characters);
        }

        [HttpGet("CharClassListAddChar")]
        public ActionResult<List<CharClassListAddCharDto>> GetAddCharList()
        {
            List<CharClassListAddCharDto> classes = _charClassService.getAll().Select(c => c.ToCharClassListAddCharDto()).ToList();
            return Ok(classes);
        }

        [HttpGet("CharClassListAddChar/{id}")]
        public ActionResult<CharClassListAddCharDto> GetOneAddCharList([FromRoute] int id)
        {
            CharClassListAddCharDto charClass = _charClassService.GetOne(id).ToCharClassListAddCharDto();
            return Ok(charClass);
        }

        [HttpPost("Add-Class")]
        public ActionResult Add([FromBody] CharClassFormDto form)
        {
            _charClassService.Add(form.ToCharClass());
            return Created();
        }
    }
}
