using Biblioteque.Models;

namespace Biblioteque.Repository
{
    public interface IRepository<T> where T : AbstractEntity
    {
        List<T> FindAll();     
        T FindById(long id);

        void GetFilesPath(ViewModel viewModel );
        void DeleteImage(string path);
        void Insert(T entity);
        void Update(T entity);
        void Delete (long id);
        void Commit();
    }
}
