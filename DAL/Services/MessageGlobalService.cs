using DAL.DTO;
using DAL.Repositories;
using Dapper;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MessageGlobalService : IMessageGlobalRepository
    {
        private readonly IDbConnection connection;


        public MessageGlobalService(IDbConnection connection)
        {
            this.connection = connection;
        }
        public void AddMessageGlobal(int expediteur, string message)
        {
            string sql = $"Exec AddMessageGlobal @expediteur ={expediteur} ,@message = '{message}'";
            try
            {

             connection.Execute(sql, new { expediteur, message });
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
                
        }

        public IEnumerable<MessageGlobalDTO> GetAllMessage()
        {
            string sql = $"SELECT * FROM MessageGlobal order by Heure ASC";
            return connection.Query<MessageGlobalDTO>(sql) ;
        }
        public MessageGlobalDTO GetLastMessageGlobal()
        {
            string sql = $"SELECT  * FROM MessageGlobal WHERE Id_MessageGlobal = (SELECT MAX( Id_MessageGlobal )  FROM MessageGlobal )";
            return connection.Query<MessageGlobalDTO>(sql).FirstOrDefault();
        }
    }
}
