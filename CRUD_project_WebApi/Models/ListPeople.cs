using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_project_WebApi.Models
{
    public class ListPeople
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int ContactNO { get; set; }

        public string Province { get; set; }
        public object Category { get; internal set; }
    }
}