using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class ToDoListForPerson : ToDoListStub
    {
        [JsonProperty("assigned_todos")]
        public IEnumerable<ToDoListItemStub> AssignedToDos { get; set; }
    }
}