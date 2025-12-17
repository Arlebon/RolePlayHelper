using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.API.Models.Language;
using RolePlayHelper.API.Models.Race;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly LanguageService _languageService;
        public LanguageController(LanguageService languageService)
        {
            _languageService = languageService;
        }


        [HttpGet]
        public ActionResult<List<LanguageListDTO>> GetAll()
        {
            List<LanguageListDTO> languages = _languageService.GetAll().Select(l => l.ToLanguageListDTO()).ToList();
            return Ok(languages);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add([FromBody] LanguageFormDto formDto)
        {
            _languageService.Add(formDto.ToLanguage());
            return Created();
        }

        [HttpGet("LanguageListFiltered")]
        public ActionResult GetSomeByName([FromQuery] string filter)
        {
            List<LanguageListDTO> languages = _languageService.GetSomeByName(filter).Select(l => l.ToLanguageListDTO()).ToList();
            return Ok(languages);
        }

    }
}
