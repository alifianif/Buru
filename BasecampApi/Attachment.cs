using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class Attachment
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("byte_size")]
        public int ByteSize { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("creator")]
        public PersonStub Creator { get; set; }
        [JsonProperty("attachable")]
        public TypeMeta Attachable { get; set; }
    }
}