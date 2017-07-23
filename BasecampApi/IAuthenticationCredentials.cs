using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace Buru.BasecampApi
{
    public interface IAuthenticationCredentials
    {
        NetworkCredential GetCredentials();
        string GetEndPointUrlBase();
    }
}