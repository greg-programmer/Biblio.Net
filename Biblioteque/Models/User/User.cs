using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models.User
{
    public class User : AbstractEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        

        // user ID from AspNetUser table.
         
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } 
        
        public string Password { get; set; }
        public List<Livre>? Livres { get;}
    }
}

