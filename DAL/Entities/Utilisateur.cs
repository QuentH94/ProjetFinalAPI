using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using System.Xml;

namespace DAL.Entities
{
    public class Utilisateur
    {
    public int UtilisateurId { get; set; }
    public string Pdp { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Pseudo { get; set; }
    public string Email { get; set; }
    public string Mdp { get; set; }
    public DateTime DateDeCreation { get; set; }   
    public bool Connecte { get; set; }

    }
}
