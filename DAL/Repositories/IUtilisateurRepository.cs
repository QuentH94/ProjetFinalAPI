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
        public void Register(Utilisateur u);
        public bool EmailAlreadyUsed(string email);
        public bool PseudoAlreadyUsed(string pseudo);
        public UtilisateurDTO Login(string email, string mdp);
        public UtilisateurDTO GetUserById(int id);
        public void Logout(int id);
        public IEnumerable<UtilisateurDTO> GetAll();
        public UtilisateurDTO GetByPseudo(string pseudo);
        public void UpdateNomPrenom(string nom, string prenom, int id);
        public UtilisateurDTO GetByEmail(string email);


    }
}
