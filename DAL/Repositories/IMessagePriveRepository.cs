using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IMessagePriveRepository
    {
        public IEnumerable<MessagePriveDTO> GetAllMessagePrive();
        public void AddMessagePrive(int expediteur, int destinataire, string message);
        public MessagePriveDTO GetLastMessagePrive();
    }
}
