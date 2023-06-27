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
        public void SendFriendResquest(int user1, int user2, int demandeur);
        public IEnumerable<AmiDTO> GetAllFriend();
        public IEnumerable<InvitationDTO> GetAllInvitations();
        public void Accepted(int id);
        public void Refused(int id);
        public void DeleteInvitation(int id);
        public void DeleteFriend(int user1, int user2);





    }
}
