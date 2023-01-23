using BibliAuth.Data;
using BibliAuth.Models;

namespace BibliAuth.Services
{
    public class LivreServices : Services
    {
        ApplicationDbContext context;

        public LivreServices(ApplicationDbContext context)
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
