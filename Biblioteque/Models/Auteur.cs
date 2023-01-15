using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models
{
    public class Auteur : AbstractEntity
    {
        [Required(ErrorMessage ="*Quel est le nom de l'auteur ?")]
        [Display(Name ="Nom de l'auteur")]
        public string ?Nom { get; set; }
        [Required(ErrorMessage ="*Quel est le prénom de l'auteur")]
        [Display(Name = "Prénom de l'auteur")]
        public string ?Prenom { get; set; }
        [Required]
        [Display(Name = "Date de naissance de l'auteur")]
        public DateTime Date_Naissance { get; set; }
        [Display(Name = "Date de mort de l'auteur")]
        public DateTime Date_Mort { get; set; }

        //public List<AuteurLivre> ?AuteurLivres { get; set; }
        public ICollection<Livre> ?Livres { get; set; }
        public long LivreId { get; set; }
    }
}
