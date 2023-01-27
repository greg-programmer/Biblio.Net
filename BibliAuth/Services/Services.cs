using BibliAuth.Data;
using BibliAuth.Models;
using BibliAuth.Repository;
using Microsoft.EntityFrameworkCore;

namespace BibliAuth.Services
{
    public class Services : IServices
    {
        private ApplicationDbContext Context;

        public Services(ApplicationDbContext context)
        {
            Context = context;
        }

        public void FavoriteBook(bool heart, List<Livre> livrelist, long id)
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

        public List<Livre> InputSearch(string input)
        {
            return Context.Livre.Where(b => b.Titre.Contains(input))
                .Include("Genres")
                .Include("Auteurs")
                .ToList();
        }
    }
}
