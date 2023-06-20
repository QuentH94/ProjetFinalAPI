using DAL.Entities;
using ProjetFinalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUtilisateurRepository
    {
       void Register(Utilisateur u);
        public bool EmailAlreadyUsed(string email);
        public bool PseudoAlreadyUsed(string pseudo);
        public UtilisateurDTO Login(string email, string mdp);
        public UtilisateurDTO GetUserById(int id);
    }
}
