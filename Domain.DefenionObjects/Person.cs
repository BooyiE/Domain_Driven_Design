using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DefenionObjects
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string ContactNO { get; set; }

        public string Province { get; set; }
    }
}
