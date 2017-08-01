using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.Models
{
    public class Authorization
    {
        public string access_token { get; set; }
        public Identity identity { get; set; }
        public ICollection<Accounts> accounts { get; set; }
    }
}