using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.BasecampApi.Managers
{
    public class ManagerBase
    {
        internal Api Api { get; set; }

        internal ManagerBase(Api api)
        {
            Api = api;
        }
    }
}