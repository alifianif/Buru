using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi
{
    public class Upload
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("attachments")]
        internal IEnumerable<Attachment> Attachments { get; set; }

        public Attachment Attachment
        {
            get
            {
                return Attachments.FirstOrDefault();
            }
        }
    }
}