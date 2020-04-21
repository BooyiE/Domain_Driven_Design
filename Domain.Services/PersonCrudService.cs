using Data;
using Domain.DefenionObjects;
using Repositories;
using System.Collections.Generic;

namespace Domain.Services
{
    public class PersonCrudService
    {
        public List<Person> GetAll()
        {

            var personRepository = new PersonRepository();

            var people = personRepository.GetAll();

            return people;

        }
        public void CreatePeople(Person person)
        {
            var personRepository = new PersonRepository();

            personRepository.createPeople(person);
        }
        public void updatePeople(int Id, Person person)
        {
            var personRepository = new PersonRepository();

            personRepository.updatePeople(Id, person);
        }
        public void deletePeople(int id)
        {
            var personRepository = new PersonRepository();

            personRepository.deletePeople(id);
        }
    }
}