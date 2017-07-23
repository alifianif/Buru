using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Buru.BasecampApi.Managers
{
    public class PeopleManager : ManagerBase
    {
        public PeopleManager(Api api) : base(api)
        {

        }

        public IEnumerable<PersonStub> Get()
        {
            var people = Api.Get<IEnumerable<PersonStub>>("/people.json");
            return people;
        }

        public Person Get(int personId)
        {
            var person = Api.Get<Person>("/people/{0}.json".FormatWith(personId));
            return person;
        }

        public Person GetCurrent()
        {
            var person = Api.Get<Person>("/people/me.json");
            return person;
        }

        public bool Delete(PersonStub person)
        {
            return Delete(person.Id);
        }

        public bool Delete(int personId)
        {
            return Api.Delete("/people/{0}.json".FormatWith(personId));
        }
    }
}