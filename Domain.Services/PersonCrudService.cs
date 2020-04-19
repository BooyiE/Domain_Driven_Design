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
        public void CreatePeople(Person_data person)
        {
            var personRepository = new PersonRepository();

               personRepository.CreatePeople(person);
        }
        public void UpdatePeople(int Id, Person_data person)
        {
            var personRepository = new PersonRepository();

            personRepository.UpdatePeople(Id, person);
        }
        public void DeletePeople(int id)
        {
            var personRepository = new PersonRepository();

            personRepository.DeletePeople(id);
        }
    }
}
