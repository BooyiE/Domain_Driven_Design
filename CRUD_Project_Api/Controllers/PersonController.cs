using CRUD_Project_Api.Models;
using Data;
using Domain.DefenionObjects;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;
using System.Web.Http;

namespace CRUD_Project_Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]

        public IEnumerable GetPeople()
        {
            var personCrudService = new PersonCrudService();
            var people = personCrudService.GetAll();
            var peopleModels = people.Select(person => PersonModel.FromDomain(person));
            return peopleModels.ToList();

        }
        [Microsoft.AspNetCore.Mvc.HttpGet("{Id}")]

        public PersonModel GetPersonById(int id)
        {
            var personCrudService = new PersonCrudService();
            var person = personCrudService.GetPersonById(id);
            PersonModel PersonFromDomain = null;
            if (person != null)
                PersonFromDomain = PersonModel.FromDomain(person);
            return PersonFromDomain;

        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult createPeople(PersonModel person)
        {
            var personCrudService = new PersonCrudService();
            personCrudService.createPeople(person.ToDomain());
            //return CreatedAtAction("GetPeopleById", new { Id = person.Id }, person);
            return Created($"https://localhost:44375/person/{person.Id}", person);
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("{Id}")]
        public IActionResult updatePeople(int id, PersonModel person)
        {
            var personCrudService = new PersonCrudService();
            personCrudService.updatePeople(id, person.ToDomain());
            return Ok(GetPersonById(id));
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{Id}")]
        public IActionResult deletePeople(int Id)
        {
            var personCrudService = new PersonCrudService();
            personCrudService.deletePeople(Id);
            return Ok(GetPeople());
        }
    }
}