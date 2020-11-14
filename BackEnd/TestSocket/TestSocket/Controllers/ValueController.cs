using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TestOwin.Controllers
{
    [RoutePrefix("api/value")]
    public  class ValueController : ApiController
    {

        Person[] personList = new Person[] {
            new Person { Id= 1,Age = 2,Name="DANNY"},
            new Person { Id = 2,Age = 3,Name = "Danny123"},
            new Person { Id =3,Age = 4,Name = "dANNY456"}
        };

        [HttpGet]
        public string GetValue()
        {
            return "Hello World";
        }

        
        [HttpGet,Route("getall")]
        public List<Person> GetListAll()
        {
            HttpContext httpContext=HttpContext.Current;
            var context = Request.GetOwinContext();
            return personList.ToList();
        }

        [HttpGet]
        public Person Get(int id)
        {
            var person= personList.FirstOrDefault(p => p.Id == id);
            return person;
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
