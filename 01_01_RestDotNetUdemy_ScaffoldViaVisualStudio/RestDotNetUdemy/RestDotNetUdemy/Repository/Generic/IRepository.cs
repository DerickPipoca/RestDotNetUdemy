using RestDotNetUdemy.Models.Base;

namespace RestDotNetUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T? FindById(long id);
        List<T> FindAll();
        T? Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}