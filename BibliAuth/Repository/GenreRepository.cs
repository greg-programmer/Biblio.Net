using BibliAuth.Data;
using BibliAuth.Models;

namespace BibliAuth.Repository
{
    public class GenreRepository : Repository<Genre>
    {
        private ApplicationDbContext Context;

        public GenreRepository(ApplicationDbContext context) : base(context)
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
            return Context.Genre     
                .FirstOrDefault(x => x.LivreId == id);
        }
        public void Insert(ViewModel viewModel)
        {
            dbSet.Add(viewModel.GenreViewM_Nolist);
        }

    }
}
    