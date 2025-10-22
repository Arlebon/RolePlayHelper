using Microsoft.AspNetCore.Mvc;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.API.Mappers;
using RolePlayHelper.DL.Entities;
using RolePlayHelper.API.Services;
using Microsoft.AspNetCore.Authorization;
using RolePlayHelper.API.Models.User;
using RolePlayHelper.API.Models.Character;

namespace RolePlayHelper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;
        private readonly CharacterService _characterService;
        public UserController(CharacterService characterService,UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
            _characterService = characterService;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] UserRegisterFormDto form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userService.CreateUser(form.ToUser());
            return Created();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginFormDto form)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // on recupere l'utilisateur
            User user  = _userService.Login(form.Login, form.Password);

            string token = _authService.GenerateToken(user);

            return Ok(new {token});
        }

        

    }
}
