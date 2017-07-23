using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.BasecampApi
{
    public interface IMimeTypeResolver
    {
        string GetMimeType(string extension);
    }
}