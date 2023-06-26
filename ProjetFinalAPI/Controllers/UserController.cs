using BLL.Interfaces;
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
        private readonly IAmiRepository _amiService;
        private readonly ILoginService _loginService;

        public UserController(IUtilisateurRepository utilisateurService, ILoginService loginService, IAmiRepository amiService)
        {
            _utilisateurService = utilisateurService;
            _loginService = loginService;
            _amiService = amiService;
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
        public ActionResult<string> Login(LoginDTO loginDto)
        {
            if (ModelState.IsValid)
            {
                if (_utilisateurService.EmailAlreadyUsed(loginDto.Email))
                {
                    string? jwt = _loginService.Login(loginDto.Email,loginDto.Mdp);
                    UtilisateurDTO u = _utilisateurService.GetByEmail(loginDto.Email);
                    

                    if (!string.IsNullOrEmpty(jwt))
                    {
                        return Ok(jwt);
                    }
                }
            }
            return BadRequest();
        }

        [HttpPut("Logout")]
        public IActionResult Logout(int id)
        {
            UtilisateurDTO u = _utilisateurService.GetUserById(id);
            
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


        [HttpGet("pseudo")]
        public ActionResult<UtilisateurDTO> GetByPseudo(string pseudo)
        {
            UtilisateurDTO user = _utilisateurService.GetByPseudo(pseudo);
            return user is not null ? Ok(user) : BadRequest();
        }

        [HttpGet]
        public ActionResult<UtilisateurDTO> GetAll()
        {          
               return Ok(_utilisateurService.GetAll());    
        }

        [HttpPatch("NomPrenom")]
        public IActionResult UpdateNomPrenom(UpdateNomPrenomDTO uDTO,int id)
        {
            if (ModelState.IsValid)
            {
                _utilisateurService.UpdateNomPrenom(uDTO.Prenom, uDTO.Nom, id);
                return Ok();
            }
            return BadRequest();
        }

    

    }
}
