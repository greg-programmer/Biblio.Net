using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models.User
{
    public class User : AbstractEntity
    {
        public int LivreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        

        // user ID from AspNetUser table.
         
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } 
        
        public string Password { get; set; }
    }
}

