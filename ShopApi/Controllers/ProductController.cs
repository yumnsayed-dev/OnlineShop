using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShopCore.Domain;

namespace ShopApi.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IProduct _product;
        
        public ProductController(IProduct product)
        {
            _product = product;
           
        }

  
        [HttpGet]
        [Route("GetListOfProducts")]
        public ActionResult<List<ShopCore.Dtos.ProductsVM>> GetListOfProducts(string? catId)
        {
            var products = _product.GetProductList();

            return Ok(products);
        }
            [HttpGet("GetSingleProduct/{id}")]
        public  ActionResult<ShopCore.Dtos.ProductsVM> GetProduct(int id)
        {
            var singleProduct =  _product.GetProductById(id);

            return Ok(singleProduct);
        }

    }
}
