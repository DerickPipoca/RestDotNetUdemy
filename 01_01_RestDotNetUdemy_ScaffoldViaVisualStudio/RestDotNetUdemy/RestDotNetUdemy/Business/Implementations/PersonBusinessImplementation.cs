using RestDotNetUdemy.Data.Converter.Implementations;
using RestDotNetUdemy.Data.VO;
using RestDotNetUdemy.Models;
using RestDotNetUdemy.Models.Context;
using RestDotNetUdemy.Repository;
using RestDotNetUdemy.Repository.Generic;

namespace RestDotNetUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            var instance = _repository.FindById(id);
            return _converter.Parse(instance!);
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity!);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}