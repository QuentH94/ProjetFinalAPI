using DAL.DTO;
using ProjetFinalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IAmiRepository
    {
        public void addFriend(int friendId, int userId);
        public IEnumerable<AmiDTO> GetAllFriend(int id);
        public void UpdateAmiConnecteLogin(int id);
        public void UpdateAmiConnecteLogout(int id);

    }
}
