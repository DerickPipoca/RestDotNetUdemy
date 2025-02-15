using RestDotNetUdemy.Models;
using RestDotNetUdemy.Models.Context;

namespace RestDotNetUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person? FindById(long id)
        {
            return _context.People.FirstOrDefault(e => e.Id == id);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return new Person();
            }

            var result = _context.People.FirstOrDefault(e => e.Id == person.Id);

            if (result != null)
            {
                try
                {
                    _context.People.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var person = _context.People.FirstOrDefault(e => e.Id == id);

            if (person != null)
            {
                try
                {
                    _context.People.Remove(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}