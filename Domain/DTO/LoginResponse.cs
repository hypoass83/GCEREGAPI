﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{

    public class LoginResponse
    {
       public string Message { get; set; }
       public string  Token { get; set; }

        public DateTime ExpierationDate { get; set; }
    }
}

