using CRUD_Project_Api.Models;
using Data;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;
using System.Web.Http;

namespace CRUD_Project_Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
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

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CreatePeople(Person_data persondata)
        {
            var personCrudService = new PersonCrudService();
              personCrudService.CreatePeople(persondata);
            return Ok(GetPeople());
        }
        [Microsoft.AspNetCore.Mvc.HttpPut("{Id}")]
        public IActionResult UpdatePeople(int id, Person_data persondata)
        {
            var personCrudService = new PersonCrudService();
            personCrudService.UpdatePeople(id, persondata);
            return Ok(GetPeople());
        }
        [Microsoft.AspNetCore.Mvc.HttpDelete("{Id}")]
        public IActionResult DeletePeople(int Id)
        {
            var personCrudService = new PersonCrudService();
            personCrudService.DeletePeople(Id);
            return Ok(GetPeople());
        }
    }
}