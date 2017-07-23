using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class AttachmentToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}