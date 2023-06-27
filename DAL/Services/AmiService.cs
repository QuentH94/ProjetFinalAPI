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
        public void SendFriendResquest(int user1, int user2, int demandeur)
        {
            string sql = $"Insert Into Invitation Values (0,{user1},{user2},{demandeur})";
           
            connection.Execute(sql, new { user1, user2, demandeur });
        }
        public void Accepted(int id)
        {
            string sql = $"Update Invitation SET Id_Status = 1 WHERE Id_Invitation = {id}";
            string sql2 = $"exec UpdateListAmi @id = {id}";           
            connection.Execute(sql,new { id });
            connection.Execute(sql2,new { id });
        }
        public void Refused(int id)
        {
            string sql = $"Update Invitation SET Id_Status = 2 WHERE Id_Invitation = {id}";
            connection.Execute(sql, new {id});
        }
        public void DeleteInvitation(int id)
        {
            string sql = $"DELETE FROM Invitation Where Id_Invitation = {id}";
            connection.Execute(sql , new { id });
        }


        public IEnumerable<AmiDTO> GetAllFriend()
        {
            string sql = $"SELECT * FROM EstAmi";
            return connection.Query<AmiDTO>(sql);
        }

        public IEnumerable<InvitationDTO> GetAllInvitations()
        {
            string sql = "SELECT * FROM Invitation";
            return connection.Query<InvitationDTO>(sql);
        }

        public void DeleteFriend(int user1, int user2)
        {
            string sql = $"DELETE FROM EstAmi Where Utilisateur1 = {user1} and Utilisateur2 = {user2}";
            string sql2 = $"DELETE FROM EstAmi Where Utilisateur1 = {user2} and Utilisateur2 = {user1}";
            connection.Execute(sql, new { user1,user2 });
            connection.Execute(sql2, new { user2, user1 });
        }
    }
}
