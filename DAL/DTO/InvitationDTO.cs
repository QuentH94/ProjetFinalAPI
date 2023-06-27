using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class InvitationDTO
    {
        public int Id_Invitation { get; set; }
        public int Id_Status { get; set; }
        public int Utilisateur1 { get; set; }
        public int Utilisateur2 { get; set; }
        public int Demandeur { get; set; }
    }
}
