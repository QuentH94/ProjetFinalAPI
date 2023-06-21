using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetFinalAPI.DTO;
using ProjetFinalAPI.Mapper;

namespace ProjetFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUtilisateurRepository _utilisateurService;

        public UserController(IUtilisateurRepository utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO r)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _utilisateurService.Register(r.ToDal());
            return Ok();

        }

        [HttpPost("login")]
        public ActionResult<UtilisateurDTO> Login(LoginDTO loginDto)
        {
            if (ModelState.IsValid)
            {
                if (_utilisateurService.EmailAlreadyUsed(loginDto.Email))
                {
                    UtilisateurDTO u = _utilisateurService.Login(loginDto.Email, loginDto.Mdp);                               
                        return u;                
                }

            }

            return BadRequest();
        }
        [HttpPut("Logout")]
        public IActionResult Logout(int id)
        {
            _utilisateurService.Logout(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        
        public ActionResult<UtilisateurDTO> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                UtilisateurDTO user = _utilisateurService.GetUserById(id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

    }
}
