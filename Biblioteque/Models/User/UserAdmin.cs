using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models.User
{
    public class UserAdmin : AbstractEntity
    {
        public int livreAdminId { get; set; }    
        [Required(ErrorMessage = "Veuillez saisir un prénom !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Veuillez saisir un nom !")]
        public string LastName { get; set; }

        // user ID from AspNetUser table.

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Veuillez saisir une adresse email !")]
        public string? Email { get; set; }
        [Required]
        public string ?Password { get; set; }
        public List<Livre> ?Livres { get; set; }
    }
}
