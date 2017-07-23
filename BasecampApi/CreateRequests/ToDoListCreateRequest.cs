using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace Buru.BasecampApi.CreateRequests
{
    public class ToDoListCreateRequest
    {
        [JsonIgnore]
        public int ProjectId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}