using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Project_Api.Models
{
    interface IListPeople_Interface
    {
        IEnumerable<ListPeople> GetAll();
        ListPeople Get(string name);
        ListPeople Add(ListPeople listPeople);
        void Remove(string name);
        bool Update(ListPeople listPeople);
    }
}
