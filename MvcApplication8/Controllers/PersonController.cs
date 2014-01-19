using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication8.Controllers
{
   


    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            return View(new PersonsViewModel { Persons = PersonDb.Get() });
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            PersonDb.Add(person);
            return Json(person);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public static class PersonDb
    {
        private static string[] _firstNames =
            {
                "Avrumi", "Shaya", "Yedid", "Asher", "Dovid", "Zevy", "Yaakov", "Moshe",
                "Morty"
            };

        private static string[] _lastNames = {"Friedman", "Pollack", "Goldberg", "Cohen", "Elbaz", "Floohr", 
                                             "Rosenberg", "Klein", "Katz", "Silberstein", "Braun"};


        private static List<Person> _persons;
        private static Random _random = new Random();

        public static IEnumerable<Person> Get()
        {
            if (_persons == null)
            {
                _persons = new List<Person>();
                for (int i = 1; i <= 10; i++)
                {
                    _persons.Add(new Person
                        {
                            Id = i,
                            FirstName = _firstNames[_random.Next(0, _firstNames.Length)],
                            LastName = _lastNames[_random.Next(0, _lastNames.Length)],
                            Age = _random.Next(20, 100)
                        });
                }
            }

            return _persons;
        }

        public static void Add(Person person)
        {
            person.Id = _persons.Max(p => p.Id) + 1;
            _persons.Add(person);
        }
    }

    public class PersonsViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}
