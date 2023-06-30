using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IMessageGlobalRepository
    {
        public IEnumerable<MessageGlobalDTO> GetAllMessage();
        public void AddMessageGlobal(int expediteur, string message);
        public MessageGlobalDTO GetLastMessageGlobal();
    }
}
