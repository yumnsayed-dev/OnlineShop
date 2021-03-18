
using Microsoft.AspNetCore.Mvc;
using ShopApi.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    [Route("error/{code}")]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code) {

            return new ObjectResult(new ApiResponse(code));

        }
    }
}
