using Biblioteque.Migrations;
using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteque.Repository
{
    public class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        protected BiblioContext context;
        protected DbSet<T> dbSet;
        LivreRepository livreRepository;
        GenreRepository genreRepository;
        AuteurRepository auteurRepository;      
        public Repository(BiblioContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            var t = FindById(id);
            if(context.Entry(t).State == EntityState.Detached)//Si il n'est pas attaché au context alors on l'attache au context
            {
                dbSet.Attach(t);
            }
            dbSet.Remove(t);    
        }

        public virtual void GetFilesPath(ViewModel viewModel)
        {
            string wwwRootPath = Environment.CurrentDirectory;
            string fileName = Path.GetFileNameWithoutExtension(path: viewModel.LivreViewM_Nolist.Image.FileName);          
            string extension = Path.GetExtension(viewModel.LivreViewM_Nolist.Image.FileName);
            viewModel.LivreViewM_Nolist.CheminImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath, "wwwroot", "Upload", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                viewModel.LivreViewM_Nolist.Image.CopyToAsync(stream); 
            }
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    await viewModel.LivreViewM_Nolist.Image.CopyToAsync(fileStream);
            //}
        }

        public virtual List<T> FindAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual T FindById(long id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }    

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteImage(string path)
        {
            string wwwRootPath = Environment.CurrentDirectory;
           var pathCombine =  Path.Combine(wwwRootPath, "wwwroot", "Upload", path);
            string notCover = "not_Cover.jpg";
            if (path != notCover)
                File.Delete(pathCombine);
        }
    }
}
