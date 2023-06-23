using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class AmiDTO
    {
        public int AmiId { get; set; }
        public int Ami { get; set; }
        public int StatusId { get; set; }
        public bool Connecte { get; set; }
        public int UtilisateurId { get; set; }

    }
}
