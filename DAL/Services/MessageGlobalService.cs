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
             connection.Execute(sql, new { expediteur, message });
                
        }

        public IEnumerable<MessageGlobalDTO> GetAllMessage()
        {
            string sql = $"SELECT * FROM MessageGlobal";
            return connection.Query<MessageGlobalDTO>(sql) ;
        }
    }
}
