﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
