using System.ComponentModel.DataAnnotations;

namespace ProjetFinalAPI.DTO
{
    public class LoginDTO
    {
        [Required]       
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")]
        public string Mdp { get; set; }

    }
}
