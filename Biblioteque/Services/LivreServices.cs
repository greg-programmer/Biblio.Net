using Biblioteque.Models;
using Biblioteque.Repository;

namespace Biblioteque.Services
{
    public class LivreServices : Services
    {
        BiblioContext context;

        public LivreServices(BiblioContext context)
        {
            this.context = context;
        }

        public void FavoriteBook(bool heart, List<Livre> livrelist, long id)
        {
            if (heart)
            {

                foreach (Livre livre1 in livrelist)
                {
                    if (livre1.Id == id && livrelist.Count() <= 1)
                    {
                        livre1.CoupDeCoeur = true;
                        break;
                    }
                    if (livre1.Id == id && livrelist.Count() > 1)
                    {
                        livre1.CoupDeCoeur = true;                        
                    }
                    if (livre1.Id != id && livrelist.Count() > 1)
                    {
                        livre1.CoupDeCoeur = false;
                    }               
                }
            }
            else
            {
                foreach (Livre livre1 in livrelist)
                {
                    if (livre1.Id == id)
                    {
                        livre1.CoupDeCoeur = false;
                        break;
                    }
                }
            }
        }
    }
}
