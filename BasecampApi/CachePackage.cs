using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.BasecampApi
{
    public class CachePackage : ICachePackage
    {
        public string Key { get; set; }
        public string ETag { get; set; }
        public DateTime LastModified { get; set; }
        public string Url { get; set; }
        public string ResponseBody { get; set; }
    }
}