using CRUD_Project_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Xml.Serialization;

namespace CRUD_Project_Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]

    public class PeopleListController : ControllerBase
    {
        public List<ListPeople> people = new List<ListPeople>
        {
           new ListPeople { Name = "Nontobeko", Surname = "Xaba", Gender = "Female", ContactNO = 0783678221, Province = "KwaZulu Natal" },
            new ListPeople { Name = "Agnes", Surname = "Hamilton", Gender = "Female", ContactNO = 0854576571, Province = "Northern cape" },
            new ListPeople { Name = "William", Surname = "Morley", Gender = "Male", ContactNO = 0856893591, Province = "Gauteng" },
            new ListPeople { Name = "Skhumkane", Surname = "Mlotshwa", Gender = "Male", ContactNO = 0776138700, Province = "Free State" },
        };

        public void Serialize(List<ListPeople> people)
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\WebApi\CRUD\CRUD_project_WebApi\CRUD_Project_Api\PeopleList.xml";
            TextWriter txtWriter = new StreamWriter(FilePath);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ListPeople>));

            serializer.Serialize(txtWriter, people);

            txtWriter.Close();
        }
        public List<ListPeople> peoples()
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\WebApi\CRUD\CRUD_project_WebApi\CRUD_Project_Api\PeopleList.xml";
            List<ListPeople> peoples;
            XmlSerializer serializer = new XmlSerializer(typeof(List<ListPeople>));
            using (Stream reader = new FileStream(FilePath, FileMode.Open))
            {
                peoples = (List<ListPeople>)serializer.Deserialize(reader);

            }
            return peoples;

        }




        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<ListPeople> GetAll()
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\WebApi\CRUD\CRUD_project_WebApi\CRUD_Project_Api\PeopleList.xml";
            if (!(System.IO.File.Exists(FilePath)))
                Serialize(people);
            return peoples();
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CreatePeople(ListPeople listPeople)
        {
            var person = peoples();
            person.Add(listPeople);
            Serialize(person);
            return Ok(peoples());
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("{Name}")]
        public IActionResult UpdatePeople(string name, ListPeople listpeople)
        {
            var people = peoples();
            if (name != listpeople.Name)
            {
                return BadRequest();
            }
            var selectedPerson = people.FirstOrDefault(person => person.Name == name);

            selectedPerson.Name = listpeople.Name;
            selectedPerson.Surname = listpeople.Surname;
            selectedPerson.Gender = listpeople.Gender;
            selectedPerson.Province = listpeople.Province;
            selectedPerson.ContactNO = listpeople.ContactNO;


            return Ok(peoples());
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{Name}")]
        public IActionResult DeleteListPeople(string name)
        {
            var person = peoples();
            var selectedPerson = from selected in person
                                 where selected.Name == name
                                 select selected;
            if (selectedPerson == null)
            {
                return NotFound();
            }
            ListPeople remove = null;
            foreach (var selected in selectedPerson)
            {
                remove = selected;
            }
            person.Remove(remove);
            Serialize(person);
            return Ok(peoples());
        }
    }
}
