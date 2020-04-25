using Data;
using Domain.DefenionObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Repositories
{
    public class PersonRepository
    {
        public Person ToDomain(Person personData)
        {
            return new Person
            {
                Id = personData.Id,
                Name = personData.Name,
                Surname = personData.Surname,
                Gender = personData.Gender,
                ContactNO = personData.ContactNO,
                Province = personData.Province
                // set rest of properties.
            };
        }
        public List<Person> peoplelist = new List<Person>
        {
           new Person { Id = 1, Name = "Nontobeko", Surname = "Xaba", Gender = "Female", ContactNO = "0783678221", Province = "KwaZulu Natal" },
            new Person { Id = 2, Name = "Agnes", Surname = "Hamilton", Gender = "Female", ContactNO = "0854576571", Province = "Northern cape" },
            new Person { Id = 3, Name = "William", Surname = "Morley", Gender = "Male", ContactNO = "0856893591", Province = "Gauteng" },
            new Person { Id = 4, Name = "Skhumkane", Surname = "Mlotshwa", Gender = "Male", ContactNO = "0776138700", Province = "Free State" },
        };
        public void Serialize(List<Person> people)
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\Domain_Driven_Design-ddd-\CRUD_Project_Api\People.xml";
            TextWriter txtWriter = new StreamWriter(FilePath);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            serializer.Serialize(txtWriter, people);

            txtWriter.Close();
        }
        public List<Person> deserializer()
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\Domain_Driven_Design-ddd-\CRUD_Project_Api\People.xml";
            List<Person> peoples;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (Stream reader = new FileStream(FilePath, FileMode.Open))
            {
                peoples = (List<Person>)serializer.Deserialize(reader);

            }
            return peoples;
        }
        public List<Person> GetAll()
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\Domain_Driven_Design-ddd-\CRUD_Project_Api\People.xml";

            if (!(File.Exists(FilePath)))
                Serialize(peoplelist);

            var peopleData = deserializer();

            var people = peopleData.Select(person => ToDomain(person));

            return people.ToList();
        }
        public Person GetPersonById(int id)
        {
            var people = GetAll();
            var selectedpersonById = people.FirstOrDefault(person => person.Id == id);
            Person _person = null;
            if (selectedpersonById != null)
            {
                _person = ToDomain(selectedpersonById);
            }
            return _person;
        }

        public void createPeople(Person personDatas)
        {
            var peopleData = deserializer();
            peopleData.Add(personDatas);
            Serialize(peopleData);
            peopleData.Select(person => ToDomain(person));
        }

        public void updatePeople(int Id, Person personDatas)
        {
            var peopleData = deserializer();
            var selectedPerson = peopleData.FirstOrDefault(person => person.Id == Id);
            if (selectedPerson != null)
            {
                selectedPerson.Id = personDatas.Id;
                selectedPerson.Name = personDatas.Name;
                selectedPerson.Surname = personDatas.Surname;
                selectedPerson.Gender = personDatas.Gender;
                selectedPerson.Province = personDatas.Province;
                selectedPerson.ContactNO = personDatas.ContactNO;
                Serialize(peopleData);
            }

        }

        public void deletePeople(int id)
        {
            var peopleData = deserializer();
            var selectedPerson = peopleData.FirstOrDefault(person => person.Id == id);
            peopleData.Remove(selectedPerson);
            Serialize(peopleData);
        }

    }
}



