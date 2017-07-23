using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Buru.BasecampApi.CreateRequests
{
    public class UploadCreateRequest
    {
        [JsonIgnore]
        public int ProjectId { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("attachments")]
        public IEnumerable<AttachmentToken> Attachments { get; set; }
        [JsonProperty("subscribers")]
        public IEnumerable<int> Subscribers { get; set; }

        internal void SetAttachmentToken(AttachmentToken token)
        {
            Attachments = new AttachmentToken[1] { token };
        }
    }
}