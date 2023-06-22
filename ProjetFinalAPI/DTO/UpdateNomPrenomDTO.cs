using System.ComponentModel.DataAnnotations;

namespace ProjetFinalAPI.DTO
{
    public class UpdateNomPrenomDTO
    {
        [Required]
        public string Nom {  get; set; }

        [Required]
        public string Prenom { get; set; }
    }
}
