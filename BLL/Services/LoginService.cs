using BLL.Interfaces;
using DAL.Repositories;
using ProjetFinalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IJwtService _jwtService;
        private readonly IUtilisateurRepository _uRepository;

        public LoginService(IJwtService jwtService, IUtilisateurRepository uRepository)
        {
            _jwtService = jwtService;
            _uRepository = uRepository;
        }

        public string Login(string mail, string mdp)
        {
            UtilisateurDTO u = _uRepository.Login(mail, mdp);
            return _jwtService.GetToken(u);
        }
    }
}
