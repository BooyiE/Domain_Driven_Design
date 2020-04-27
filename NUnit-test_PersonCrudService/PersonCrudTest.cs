using Domain.DefenionObjects;
using Domain.Services;
using NUnit.Framework;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace NUnit_test_PersonCrudService
{
    [TestFixture]
    public class PersonCrudTest
    {
        public PersonCrudService personCrudService;
            
        [SetUp]
        public void Setup()
        {
            personCrudService = new PersonCrudService(); 
            
        }

        [Test]
        public void Test_GetAll()
        {
            var people = personCrudService.GetAll();
            Assert.IsNotNull(people);
        }
        [Test]
        public void Test_GetPersonById()
        {
            var people = personCrudService.GetAll();
            var personToFind = people.Last();
            var person = personCrudService.GetPersonById(personToFind.Id);
            Assert.AreEqual(personToFind.Id, person.Id);
        }
        [Test]
        public void Test_createPeople()
        {
            var person = new Person {Id = 55, Name = "Booyie", Surname = "Phofuyagae", ContactNO= "0787865510", Gender = "Female", Province = "Gauteng" };
            personCrudService.createPeople(person);
            var createdPerson = personCrudService.GetPersonById(person.Id);
            Assert.IsNotNull(createdPerson);
        }
        [Test]
        public void Test_updatePeople()
        {
            var person = new Person { Id = 55, Name = "Buyile", Surname = "Phofuya", ContactNO = "0787865510", Gender = "Female", Province = "Gauteng" };
            var updatingPerson = personCrudService.GetPersonById(55);
            personCrudService.updatePeople(updatingPerson.Id, person);
            var updatedPerson = personCrudService.GetPersonById(55);
            Assert.AreEqual(person.Name, updatedPerson.Name);
        }
        [Test]
        public void deletePeople()
        {
            personCrudService.deletePeople(55);
            Assert.IsNull(personCrudService.GetPersonById(55));
        }
    }
}