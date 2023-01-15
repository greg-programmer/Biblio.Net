namespace Biblioteque.Models
{
    public class ViewModel 
    {
        public List<Livre> ?LivreViewM { get; set; }
        public Livre? LivreViewM_Nolist{ get; set; }
        public List<Auteur> ?AuteurViewM { get; set; }    
        public Auteur? AuteurViewM_Nolist{ get; set; }
        public List<Genre>? GenreViewM { get; set; }
        public Genre? GenreViewM_Nolist{ get; set; }
    }
}
 