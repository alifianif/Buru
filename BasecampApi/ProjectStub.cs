using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class ProjectStub : ApiStubObject<Project>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        [JsonProperty("starred")]
        public bool Starred { get; set; }

        public override Project GetDetail()
        {
            var project = Api.GetResponseFromUrl<Project>(Url);
            project.Api = Api;
            return project;
        }
    }
}