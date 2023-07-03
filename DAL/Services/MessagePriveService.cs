using DAL.DTO;
using DAL.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MessagePriveService : IMessagePriveRepository
    {
        private readonly IDbConnection connection;

        public MessagePriveService(IDbConnection connection)
        {
            this.connection = connection;
        }
        public void AddMessagePrive(int expediteur, int destinataire, string message)
        {
            string sql = $"Exec AddMessagePrive @expediteur ={expediteur}, @destinataire ={destinataire} ,@message = '{message}'";
            try
            {
                connection.Execute(sql, new { expediteur, destinataire, message });
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }

  

        public IEnumerable<MessagePriveDTO> GetAllMessagePrive()
        {
            string sql = $"SELECT * FROM MessagePrive order by Heure ASC";
            return connection.Query<MessagePriveDTO>(sql);
        }
        public MessagePriveDTO GetLastMessagePrive()
        {
            string sql = $"SELECT  * FROM MessagePrive WHERE Id_MessagePrive = (SELECT MAX( Id_MessagePrive )  FROM MessagePrive )";
            return connection.Query<MessagePriveDTO>(sql).FirstOrDefault();
        }
    }
}
