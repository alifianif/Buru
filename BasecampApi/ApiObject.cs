using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.BasecampApi
{
    public abstract class ApiStubObject<T> : ApiObject
    {
        public abstract T GetDetail();
    }

    public abstract class ApiObject
    {
        public Api Api { get; set; }
    }
}