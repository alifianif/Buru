using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.BasecampApi
{
    public interface IResponseCache
    {
        void Insert(ICachePackage package);
        ICachePackage Get(string key);
    }
}