using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Project_Api.Models
{
    [ApiController]
    [Route("[controller]")]
    public class Implement_Interface : IListPeople_Interface
    {
        private List<ListPeople> people = new List<ListPeople>();
        private string newname = "buyi";

        public Implement_Interface()
        {
            Add(new ListPeople { Name = "Nontobeko", Surname = "Xaba", Gender = "Female", ContactNO = 0783678221, Province = "KwaZulu Natal" });
            Add(new ListPeople { Name = "Agnes", Surname = "Hamilton", Gender = "Female", ContactNO = 0854576571, Province = "Northern cape" });
            Add(new ListPeople { Name = "William", Surname = "Morley", Gender = "Male", ContactNO = 0856893591, Province = "Gauteng" });
            Add(new ListPeople { Name = "Skhumkane", Surname = "Mlotshwa", Gender = "Male", ContactNO = 0776138700, Province = "Free State" });
        }

        [HttpGet]
        public IEnumerable<ListPeople> GetAll()
        {
            return people;
        }

        public ListPeople Get(string name)
        {
            return people.Find(b => b.Name == name);
        }
        public ListPeople Add(ListPeople listPeople)
        {
            if (listPeople == null)
            {
                throw new ArgumentNullException("listpeople");
            }
            listPeople.Name = newname;
            people.Add(listPeople);
            return listPeople;

        }
        public void Remove(string name)
        {
            people.RemoveAll(b => b.Name == name);
        }

        public bool Update(ListPeople listPeople)
        {
            if (listPeople == null)
            {
                throw new ArgumentNullException("listpeople");
            }
            int index = people.FindIndex(b => b.Name == listPeople.Name);
            if (index == -1)
            {
                return false;
            }
            people.RemoveAt(index);
            people.Add(listPeople);
            return true;
        }
    }
}
