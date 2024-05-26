using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LearnHubAPP.Models
{
    public class Formateur
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        public string? Prenom { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        [RegularExpression(@"^\+?[0-9]{0,3}?[0-9]{8}$", ErrorMessage = "Le numéro de téléphone n'est pas dans un format valide.")]
        public string? NumTel { get; set; }
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse email valide.")]
        public string? Email { get; set; }

        [StringLength(1000, ErrorMessage = "La biographie du formateur ne doit pas dépasser 1000 caractères.")]
        public string? Biographie { get; set; }

        public virtual ICollection<Formation>? Formations { get; set; }
    }
}
