
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BibliAuth.Models
{
    
        public class Livre : AbstractEntity
        {
            [Required(ErrorMessage = "Quel est le titre du livre ?")]
            [Display(Name = "Titre du livre")]
            public string? Titre { get; set; }
            [Display(Name = "Date de parution")]
            public DateTime? Date_Parution { get; set; }
            [Required(ErrorMessage = "Un résumé vous aidera à attirer le lecteur !")]
            [MaxLength(500)]
            [Display(Name = "Résumer du livre ...(500 caractères maximum)")]
            public string? Synopsis { get; set; }

            public enum Type_Livre
            {
                BD,
                Magazine,
                Roman,
                Théâtre,
                Policier,
                Manga
            }
         [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.jpeg|.jpg|.gif|"")$",
                ErrorMessage = "Format autorisés : jpeg, jpg, gif.")]
            [NotMapped]
            public IFormFile? Image { get; set; }
            public string? CheminImage { get; set; }
            public ICollection<Genre>? Genres { get; set; }
            public ICollection<Auteur>? Auteurs { get; set; }
            public bool CoupDeCoeur { get; set; } = false;           

        }    
}
