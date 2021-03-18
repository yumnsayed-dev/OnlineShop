using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Errors
{
    public class ApiResponse
    {
  
        public ApiResponse(int statusCode , string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request.",
                401 => "You are not Authorized.",
                404 => "Ops ,Resource is not Found.",
                500 => "We are having a techincal problem, please try again Later.",
                _ => null
            };
        }
    }
}
