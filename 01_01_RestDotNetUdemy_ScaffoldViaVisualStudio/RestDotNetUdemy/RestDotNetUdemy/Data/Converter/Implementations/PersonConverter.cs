using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestDotNetUdemy.Data.Converter.Contract;
using RestDotNetUdemy.Data.VO;
using RestDotNetUdemy.Models;

namespace RestDotNetUdemy.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin != null)
            {
                return new Person()
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Gender = origin.Gender,
                    Address = origin.Address
                };
            }
            return null!;
        }

        public PersonVO Parse(Person origin)
        {
            if (origin != null)
            {
                return new PersonVO()
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Gender = origin.Gender,
                    Address = origin.Address
                };
            }
            return null!;
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin != null)
            {
                return origin.Select(e => Parse(e) ?? new PersonVO()).ToList();
            }
            return null!;
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin != null)
            {
                return origin.Select(e => Parse(e) ?? new Person()).ToList();
            }
            return null!;
        }
    }
}