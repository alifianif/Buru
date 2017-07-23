using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class PersonStub : ApiStubObject<Person>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public override Person GetDetail()
        {
            return Api.People.Get(Id);
        }
    }
}