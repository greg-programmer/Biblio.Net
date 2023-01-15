using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteque.Repository
{
    public class GenreRepository : Repository<Genre>
    {
        private BiblioContext Context;

        public GenreRepository(BiblioContext context) : base(context)
        {
            Context = context;
        }
        //public override List<Genre> FindAll()
        //{
        //    return context.Genres.OrderByDescending(b => b.Id)
        //        .Include("Genres")
        //        .Include("Auteurs")
        //        .ToList();
        //}
        public override Genre FindById(long id)
        {
            return context.Genres                
                .FirstOrDefault(x => x.LivreId == id);
        }
        public void Insert(ViewModel viewModel)
        {
            dbSet.Add(viewModel.GenreViewM_Nolist);
        }

    }
}
    