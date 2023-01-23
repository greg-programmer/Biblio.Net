using BibliAuth.Data;
using BibliAuth.Models;


namespace BibliAuth.Repository
{
    public class AuteurRepository : Repository<Auteur>
    {
        private ApplicationDbContext Context;
        public AuteurRepository(ApplicationDbContext context) : base(context)
        {
            this.Context = context;
        }

        public override Auteur FindById(long id)
        {
            return Context.Auteur               
                .FirstOrDefault(x => x.LivreId == id);
        }
        public void Insert(ViewModel viewModel)
        {
            dbSet.Add(viewModel.AuteurViewM_Nolist);
        }
    }
}
