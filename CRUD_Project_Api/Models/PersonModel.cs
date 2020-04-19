using Domain.DefenionObjects;

namespace CRUD_Project_Api.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string ContactNO { get; set; }

        public string Province { get; set; }

        public static PersonModel FromDomain(Person person)
        {
            return new PersonModel
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
