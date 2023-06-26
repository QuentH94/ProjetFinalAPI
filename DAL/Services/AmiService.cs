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
        public void SendFriendResquest(int user1, int user2)
        {
            string sql = $"Insert Into Invitation Values (0,{user1},{user2})";
           
            connection.Execute(sql, new { user1, user2 });
        }
        public void Accepted(int id)
        {
            string sql = $"Update Invitation SET Id_Status = 1 WHERE Id_Invitation = {id}";
            
            connection.Execute(sql);
        }
        public void Refused(int id)
        {
            string sql = $"Update Invitation SET Id_Status = 2 WHERE Id_Invitation = {id}";
            connection.Execute(sql);
        }
        public void AddFriend(int u1, int u2)
        {
            string sql = $"Insert Into EstAmi Values ({u1},{u2})";
            connection.Execute(sql);
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
    }
}
