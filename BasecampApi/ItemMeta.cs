using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class ItemMeta
    {
        ItemMeta()
        {

        }

        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}