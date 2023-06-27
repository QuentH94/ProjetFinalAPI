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
    public class MessageGlobalService : IMessageGlobalRepository
    {
        private readonly IDbConnection connection;


        public MessageGlobalService(IDbConnection connection)
        {
            this.connection = connection;


        }

        public void AddMessage(int expediteur, string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageGlobalDTO> GetAllMessage()
        {
            string sql = $"SELECT * FROM MessageGlobal";
            return connection.Query<MessageGlobalDTO>(sql) ;
        }
    }
}
