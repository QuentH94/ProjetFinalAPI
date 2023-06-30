using DAL.Entities;
using DAL.Repositories;
using Dapper;
using ProjetFinalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UtilisateurService : IUtilisateurRepository
    {
        private readonly IDbConnection connection;
        
        public UtilisateurService(IDbConnection connection)
        {
            this.connection = connection;
           
        }
    
        public bool EmailAlreadyUsed(string email)
        {
            string sql = $"SELECT CAST(CASE WHEN EXISTS (SELECT email FROM Utilisateur WHERE email = '{email}') THEN 1 ELSE 0 END as BIT)";
            bool exists = connection.ExecuteScalar<bool>(sql, email);
            return exists;
        }

        public IEnumerable<UtilisateurDTO> GetAll()
        {
            string sql = $"SELECT * FROM Utilisateur";
            return connection.Query<UtilisateurDTO>(sql);
        }

        public UtilisateurDTO GetByEmail(string email)
        {
            string sql = $"SELECT * FROM Utilisateur WHERE Email = '{email}'";
            return connection.Query<UtilisateurDTO>(sql, new { email }).FirstOrDefault();
        }

        public UtilisateurDTO GetByPseudo(string pseudo)
        {
            string sql = $"SELECT * FROM Utilisateur WHERE Pseudo = '{pseudo}'";
            try
            {

            return connection.Query<UtilisateurDTO>(sql, new { pseudo }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
        }

        public UtilisateurDTO GetUserById(int id)
        {
            string sql = $"SELECT * From Utilisateur WHERE UtilisateurId = {id}";
            return connection.Query<UtilisateurDTO>(sql, new {id}).FirstOrDefault();
        }

        public UtilisateurDTO Login(string email, string mdp)
        {   
            string sql = $"SELECT * From Utilisateur WHERE Email = '{email}' AND Mdp = [dbo].[ProjetFinalHash]('{mdp}')";
            string sql2 = $"UPDATE Utilisateur SET Connecte = 1 WHERE Email = '{email}' AND Mdp = [dbo].[ProjetFinalHash]('{mdp}')";
            connection.Execute(sql2, new { email, mdp });
            return connection.QueryFirstOrDefault<UtilisateurDTO>(sql, new { email, mdp });
           
            
        }

        public void Logout(int id)
        {
            string sql = $"UPDATE Utilisateur SET Connecte = 0 WHERE UtilisateurId = '{id}'";
            connection.Execute(sql, new { id });
        }

        public bool PseudoAlreadyUsed(string pseudo)
        {
            string sql = $"SELECT pseudo From Utilisateur WHERE pseudo like '{pseudo}'";
            bool exists = connection.ExecuteScalar<bool>(sql, pseudo);
            return exists;
        }

        public void Register(Utilisateur u)
        { 
            string sql = $"exec ProjetFinalRegister @Pdp = '{u.Pdp}', @Nom = '{u.Nom}', @Prenom = '{u.Prenom}', @Email = '{u.Email}', @Pseudo = '{u.Pseudo}', @Mdp = '{u.Mdp}'";
            connection.Execute(sql, u);
        }

        public void UpdateNomPrenom(string nom, string prenom, int id)
        {
            string sql = $"UPDATE Utilisateur SET Nom = '{nom}', Prenom = '{prenom}' WHERE UtilisateurId = {id}";
            connection.Execute(sql, new {nom, prenom, id});
        }
    }
}
