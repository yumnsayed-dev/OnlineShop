﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Errors
{
    public class ApiExecption : ApiResponse
    {
        public ApiExecption(int statusCode, string message = null, string details = null) 
         : base(statusCode, message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
