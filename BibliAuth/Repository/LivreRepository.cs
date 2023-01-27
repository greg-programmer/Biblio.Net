
using BibliAuth.Data;
using BibliAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliAuth.Repository
{
    public class LivreRepository : Repository<Livre>
    {
        private ApplicationDbContext Context;
        private FileNotFoundException exceptionHandlerPathFeature;

        public LivreRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
        public override List<Livre> FindAll()
        {
            return context.Livre
                .Where(b => b.Id > 0)        
                .Include("Genres")
                .Include("Auteurs")
                .ToList();
        }
        public override Livre FindById(long id)
        {
            return context.Livre
                 .FirstOrDefault(x => x.Id == id);
        }
        public void Insert(ViewModel viewModel)
        {
            dbSet.Add(viewModel.LivreViewM_Nolist);
        }

        public async override void GetFilesPath(ViewModel viewModel)
        {
            try
            {
                string wwwRootPath = Environment.CurrentDirectory;                
                string fileName = Path.GetFileNameWithoutExtension(path: viewModel.LivreViewM_Nolist.Image.FileName);
                string extension = Path.GetExtension(viewModel.LivreViewM_Nolist.Image.FileName);
                long sizeFile = viewModel.LivreViewM_Nolist.Image.Length;                
                Console.WriteLine(sizeFile);
                viewModel.LivreViewM_Nolist.CheminImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath, "wwwroot", "Upload", fileName);
                Console.WriteLine(sizeFile);
           
                using (var stream = new FileStream(path, FileMode.Create))                {
                    
                    await viewModel.LivreViewM_Nolist.Image.CopyToAsync(stream);
                }
            }
            catch
            {
                 return;
            }

        }
        public override void DeleteImage(string path)
        {
            string wwwRootPath = Environment.CurrentDirectory;
            var pathCombine = Path.Combine(wwwRootPath, "wwwroot", "Upload", path);
            string notCover = "not_Cover.jpg";
            if (path != notCover)
                File.Delete(pathCombine);
        }
        public void InputSearch(string search, ViewModel view)
        {
            Console.WriteLine(view.LivreViewM_Nolist.Titre, search);
        }

        /* public override void Delete(long id)
{
    ImageRepository imgRep = new ImageRepository(Context);
    Livre livre = FindById(id);
    Image img = livre.Image;
    imgRep.Delete(img.Id);
    base.Delete(id);            
}*/
    }
}
