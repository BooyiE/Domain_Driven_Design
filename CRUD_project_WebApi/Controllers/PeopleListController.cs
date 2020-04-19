using CRUD_project_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_project_WebApi.Controllers
{
    public class PeopleListController : ApiController
    {
            static readonly IListPeople_Interface Mypeople = new Implement_Interface();

            //To Get the list of people
            public IEnumerable<ListPeople> GetAllListPeople()
            {
                return Mypeople.GetAll();
            }
            //To get product by Name
            public ListPeople GetListPeople(string name )
            {
                ListPeople listpeople = Mypeople.Get(name);
                if (listpeople == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                return listpeople;
            }
            //find people
            public IEnumerable<ListPeople> GetListPeoplesByCategory(string category)
            {
                 return Mypeople.GetAll().Where(b => string.Equals(b.Name == category, StringComparison.OrdinalIgnoreCase));
            // return Mypeople.GetAll().Where(b => string.Equals(b.Category, category, StringComparison.OrdinalIgnoreCase));

        }
        // Creating a new List
        public ListPeople PostListPeople(ListPeople listPeople)
            {
                listPeople = Mypeople.Add(listPeople);
                return listPeople;
            }
            public HttpResponseMessage PostPeopleList(ListPeople listPeople)
            {
                listPeople = Mypeople.Add(listPeople);
                var respond = Request.CreateResponse<ListPeople>(HttpStatusCode.Created, listPeople);
                string link = Url.Link("DefaultApi", new { id = listPeople.Name });
                respond.Headers.Location = new Uri(link);
                return respond;
            }
            //Updating the list
            public void PutPeopleList(string name, ListPeople listing)
            {
                listing.Name = name;
                if (!Mypeople.Update(listing))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                //Deleting the list
                 void DeleteListPeople(string naming)
                {
                    ListPeople listPeople = Mypeople.Get(naming);
                    if (listPeople == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    Mypeople.Remove(naming);
                }
            }
        }
}
