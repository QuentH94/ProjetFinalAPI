using DAL.DTO;
using DAL.Entities;
using DAL.Repositories;
using Dapper;
using ProjetFinalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class AmiService : IAmiRepository
    {
        private readonly IDbConnection connection;
  

        public AmiService(IDbConnection connection)
        {
            this.connection = connection;
           

        }
        public void addFriend(int friendId, int userId)
        {
            string sql = $"INSERT INTO Ami VALUES ({friendId},1,{userId},(SELECT Connecte FROM Utilisateur WHERE UtilisateurId = {friendId}))";
            connection.Execute(sql, new { friendId, userId });
        }

        public IEnumerable<AmiDTO> GetAllFriend()
        {
            string sql = $"SELECT * FROM Ami";
            return connection.Query<AmiDTO>(sql);
        }

        public void UpdateAmiConnecteLogin(int id)
        {
            string sql = $"UPDATE Ami SET Connecte = 1 WHERE Ami = '{id}'";
            connection.Execute(sql, new { id });
        }

        public void UpdateAmiConnecteLogout(int id)
        {
            string sql = $"UPDATE Ami SET Connecte = 0 WHERE Ami = '{id}'";
            connection.Execute(sql, new { id });
        }
    }
}
