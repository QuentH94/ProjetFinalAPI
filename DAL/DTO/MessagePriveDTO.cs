using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class MessagePriveDTO
    {
        public int Id_MessagePrive { get; set; }
        public int Expediteur { get; set; }
        public int Destinataire { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime Heure { get; set; }
    }
}
