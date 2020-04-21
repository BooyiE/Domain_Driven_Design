using Data;

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

        public static PersonModel FromDomain(Person_data personData)
        {
            return new PersonModel
            {
                Id = personData.Id,
                Name = personData.Name,
                Surname = personData.Surname,
                Gender = personData.Gender,
                ContactNO = personData.ContactNO,
                Province = personData.Province

            };

        }
    }
}
