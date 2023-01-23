using BibliAuth.Models;

namespace BibliAuth.Services
{
    public interface IServices
    {
        public void FavoriteBook(bool heart, List<Livre> livrelist, long id);
    }
}
