using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.JsonFormatted
{
    public class ProjectBC
    {
        public string id { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string purpose { get; set; }
        public string bookmark_url { get; set; }
        public string url { get; set; }
        public string app_url { get; set; }
        public ICollection<Dock> dock { get; set; }
    }
}