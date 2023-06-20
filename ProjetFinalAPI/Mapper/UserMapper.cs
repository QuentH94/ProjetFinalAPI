using DAL.Entities;
using ProjetFinalAPI.DTO;

namespace ProjetFinalAPI.Mapper
{
    public static class UserMapper
    {
        public static Utilisateur ToDal(this RegisterDTO r)
        {
            return new Utilisateur
            {
                Pdp = r.Pdp,
                Nom = r.Nom,
                Prenom = r.Prenom,
                Pseudo = r.Pseudo,
                Email = r.Email,
                Mdp = r.Mdp,
            };
        }
    }
}
