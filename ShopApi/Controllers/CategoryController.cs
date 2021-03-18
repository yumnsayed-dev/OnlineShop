using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopCore.Domain;
using ShopCore.Dtos;
using ShopCore.Entities;

namespace ShopApi.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        [Route("GetListOfCategory")]
        public ActionResult<List<Category>> GetListOfProducts()
        {
            var Categories = _category.GetCategoryList();

            return Ok(Categories);
        }
    }
}
