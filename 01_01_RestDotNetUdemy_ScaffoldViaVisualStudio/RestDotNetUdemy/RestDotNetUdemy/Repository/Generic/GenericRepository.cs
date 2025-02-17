using Microsoft.EntityFrameworkCore;
using RestDotNetUdemy.Models.Base;
using RestDotNetUdemy.Models.Context;

namespace RestDotNetUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySQLContext _context;

        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T? FindById(long id)
        {
            return _dataset.FirstOrDefault(e => e.Id == id);
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public T? Update(T item)
        {
            if (!Exists(item.Id))
            {
                return null;
            }

            var result = _dataset.FirstOrDefault(e => e.Id == item.Id);

            if (result != null)
            {
                try
                {
                    _dataset.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return item;
        }

        public void Delete(long id)
        {
            var item = _dataset.SingleOrDefault(e => e.Id == id);

            if (item != null)
            {
                try
                {
                    _dataset.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
        }
    }
}