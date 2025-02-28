﻿using System.ComponentModel.DataAnnotations;

namespace LearnHubApp.Models
{
    public class CategorieClient
    {
        [Key]
        public int IdCategorie { get; set; }

        [Required(ErrorMessage = "Le nom de la catégorie est requis.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom de la catégorie doit avoir entre 3 et 50 caractères.")]
        public string? NomCategorie { get; set; }

        [Required(ErrorMessage = "La description de la catégorie est requise.")]
        public string? DescriptionCat { get; set; }

        public virtual ICollection<FormationClient>? Formations { get; set; }
    }
}
