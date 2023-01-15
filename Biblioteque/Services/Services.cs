using Biblioteque.Models;

namespace Biblioteque.Services
{
    public class Services : IServices
    {
        public void FavoriteBook(bool heart ,List<Livre> livrelist, long id)
        {
            if (heart)
            {

                foreach (Livre livre1 in livrelist)
                {
                    if (livre1.Id != id || livre1.Id == id && livrelist.Count() <= 1)
                    {
                        livre1.CoupDeCoeur = true;
                        break;
                    }
                    if (livre1.Id == id && livrelist.Count() > 1)
                    {
                        livre1.CoupDeCoeur = true;
                    }
                    else
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
