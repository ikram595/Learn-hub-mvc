using System.ComponentModel.DataAnnotations;

namespace LearnHubApp.Models
{
    public class FormateurClient
    {
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse email valide.")]
        public string? Email { get; set; }

        [StringLength(1000, ErrorMessage = "La biographie du formateur ne doit pas dépasser 1000 caractères.")]
        public string? Biographie { get; set; }

        public string? ImgFormateurPath { get; set; }

        public virtual ICollection<FormationClient>? Formations { get; set; }
    }
}
