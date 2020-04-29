using Domain.DefenionObjects;

namespace Data
{
    public class Person_data
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Gender { get; set; }
        public string ContactNO { get; set; }

        public string Province { get; set; }


        public static Person_data FromDomain(Person person)
        {
            return new Person_data
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Gender = person.Gender,
                ContactNO = person.ContactNO,
                Province = person.Province

            };
        }
    }

}
