using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Biblioteque.Models
{
    public class Genre : AbstractEntity
    {
        [Display(Name = "Genre")]
        [Required(ErrorMessage ="Quel est le genre de votre livre?")]      
        public string ?Nom { get; set; }

        // le "?" permet d'indiquer que le champs peut être null
        /*public List<GenreLivre> ?GenreLivres { get; set; }*/
        public ICollection<Livre> ?Livres { get; set; }
        public long LivreId { get; set; }
    }
}
