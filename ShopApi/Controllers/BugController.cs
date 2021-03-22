using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Errors;
using ShopRepository.ShopContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    //Catching predefined status code and tittle(errorMessage) to handle execptions and errors.
    public class BugController :BaseApiController
    {
        private readonly ShopDbContext _shopContext;
        public BugController(ShopDbContext shopContext)
        {
            _shopContext = shopContext;
        }
        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secred paging";
        }

        [HttpGet("notfound")]
        public ActionResult GetNoFoundRequest() 
        {
            var dummy = _shopContext.Products.Find(-1);
            if (dummy == null)
            {
                //404 in an exiting Route
                return NotFound( new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            //Null Ref exeception
            var dummy = _shopContext.Products.Find(-1);
            var serverDummy = dummy.ToString();
            
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            //400
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNoFoundRequest(int id)
        {
            //Not Valid
            return Ok();
        }
    }
}
