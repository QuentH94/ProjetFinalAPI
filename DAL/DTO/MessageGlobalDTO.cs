using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class MessageGlobalDTO
    {
        public int Id_MessageGlobal { get; set; }
        public int Expediteur { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
