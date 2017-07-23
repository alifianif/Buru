using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class ToDoListItem : ToDoListItemStub
    {
        [JsonProperty("creator")]
        public PersonStub Creator { get; set; }

        /*[JsonProperty("comments")]
        public IEnumerable<Comment> Comments { get; set; }*/

        [JsonProperty("subscribers")]
        public IEnumerable<PersonStub> Subscribers { get; set; }
    }
}