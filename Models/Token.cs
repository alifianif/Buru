﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buru.Models
{
    public class Token
    {
        public string access_token
        {
            get;
            set;
        }
        public string expires_in
        {
            get;
            set;
        }
        public string refresh_token
        {
            get;
            set;
        }
    }
}