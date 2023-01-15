using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteque.Repository
{
    public class AuteurRepository : Repository<Auteur>
    {
        private BiblioContext Context;
        public AuteurRepository(BiblioContext context) : base(context)
        {
            this.Context = context;
        }

        public override Auteur FindById(long id)
        {
            return context.Auteurs               
                .FirstOrDefault(x => x.LivreId == id);
        }
        public void Insert(ViewModel viewModel)
        {
            dbSet.Add(viewModel.AuteurViewM_Nolist);
        }
    }
}
