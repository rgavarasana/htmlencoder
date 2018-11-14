using Newtonsoft.Json;
using ravi.learn.web.htmlencoder.Infrastructure;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ravi.learn.web.modelbinding.Controllers
{
    public class PersonsController : ApiController
    {
        private static ConcurrentBag<Person> _persons = new ConcurrentBag<Person>(new List<Person> { new Person { Id = 1, Name = "Person1" }, new Person { Id = 2, Name = "Person2" } });

        public IEnumerable<Person> Get()
        {
            return _persons;
        }

        public Person Get(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }


        public IHttpActionResult Post(Person person)
        {
            _persons.Add(person);
            return Ok();
        }


        public IHttpActionResult Put(int id, Person person)
        {
            var existing = _persons.FirstOrDefault(p => p.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Name = person.Name;
            return Ok();
        }
    }

    public class Person
    {
        public int Id { get; set; }

        [JsonConverter(typeof(HtmlEncodeConvertor))]
        public string Name { get; set; }

    }

   
}
