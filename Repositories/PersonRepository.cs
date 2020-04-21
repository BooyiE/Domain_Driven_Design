﻿using Data;
using Domain.DefenionObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Repositories
{
    public class PersonRepository
    {
            public Person ToDomain(Person_data personData)
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
        public List<Person_data> peoplelist = new List<Person_data>
        {
           new Person_data { Id = 1, Name = "Nontobeko", Surname = "Xaba", Gender = "Female", ContactNO = "0783678221", Province = "KwaZulu Natal" },
            new Person_data { Id = 2, Name = "Agnes", Surname = "Hamilton", Gender = "Female", ContactNO = "0854576571", Province = "Northern cape" },
            new Person_data { Id = 3, Name = "William", Surname = "Morley", Gender = "Male", ContactNO = "0856893591", Province = "Gauteng" },
            new Person_data { Id = 4, Name = "Skhumkane", Surname = "Mlotshwa", Gender = "Male", ContactNO = "0776138700", Province = "Free State" },
        };
        public void Serialize(List<Person_data> people)
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\Domain_Driven_Design-ddd-\CRUD_Project_Api\People.xml";
            TextWriter txtWriter = new StreamWriter(FilePath);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person_data>));

            serializer.Serialize(txtWriter, people);

            txtWriter.Close();
        }
        public List<Person_data> deserializer()
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\Domain_Driven_Design-ddd-\CRUD_Project_Api\People.xml";
            List<Person_data> peoples;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person_data>));
            using (Stream reader = new FileStream(FilePath, FileMode.Open))
            {
                peoples = (List<Person_data>)serializer.Deserialize(reader);

            }
            return peoples;
        }
        public List<Person> GetAll()
        {
            var FilePath = @"C:\Users\bbdnet2223\Desktop\Domain_Driven_Design-ddd-\CRUD_Project_Api\People.xml";

            if (!(File.Exists(FilePath)))
                Serialize(peoplelist);

            var peopleData = deserializer();//get all the people stored in your xml file

            var people = peopleData.Select(person => ToDomain(person));

            return people.ToList();
        }

        public void CreatePeople(Person_data personDatas)
        {
            var peopleData = deserializer();
            peopleData.Add(personDatas);
            Serialize(peopleData);
            peopleData.Select(person => ToDomain(person));
        }

        public void UpdatePeople(int Id, Person_data personDatas)
        {
            var peopleData = deserializer();
            var selectedPerson = peopleData.FirstOrDefault(person => person.Id == Id);

            selectedPerson.Id = personDatas.Id;
            selectedPerson.Name = personDatas.Name;
            selectedPerson.Surname = personDatas.Surname;
            selectedPerson.Gender = personDatas.Gender;
            selectedPerson.Province = personDatas.Province;
            selectedPerson.ContactNO = personDatas.ContactNO;
            Serialize(peopleData);
            peopleData.Select(person => ToDomain(person));
        }

        public void DeletePeople(int id)
        {
            var peopleData = deserializer();
            var selectedPerson = from selected in peopleData
                                 where selected.Id == id
                                 select selected;
            Person_data remove = null;
            foreach (var selected in selectedPerson)
            {
                remove = selected;
            }
            peopleData.Remove(remove);
            Serialize(peopleData);
            peopleData.Select(person => ToDomain(person));
        }

    }
}


