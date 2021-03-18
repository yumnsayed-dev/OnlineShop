using ShopCore.Domain;
using ShopCore.Entities;
using System.Collections.Generic;
using System.Linq;
using ProductsVM = ShopCore.Dtos.ProductsVM;

namespace ShopServices.ShopRepoServices
{
    public class ProductService : IProduct
    {
        private readonly IRepository<ShopCore.Entities.ProductsDto> _product;
        private readonly IRepository<Category> _category;
        private readonly IRepository<UnitOfMeasure> _unitOfMeasure;
        public ProductService( IRepository<ShopCore.Entities.ProductsDto> product, IRepository<Category> category, IRepository<UnitOfMeasure> unitOfMeasure)
        {
            _product = product;
            _category = category;
            _unitOfMeasure = unitOfMeasure;
        }


        public ProductsVM GetProductById(int ProductId)
        {

            var product = (from prods in _product.GetAll().AsQueryable().Where(X=>X.BaseId == ProductId)
                            join cat in _category.GetAll().AsQueryable() on prods.CategoryId equals cat.BaseId
                            join unit in _unitOfMeasure.GetAll().AsQueryable() on prods.UomId equals unit.BaseId
                            select new ShopCore.Dtos.ProductsVM()
                            {
                                ProductId = prods.BaseId,
                                ProductName = prods.ProductName,
                                ProductImg = prods.ProductImg,
                                DiscountPerc = prods.DiscountPerc.GetValueOrDefault(),
                                AvailablelQuantity = prods.AvailablelQuantity,
                                Category = cat.CategoryName,
                                UnitOfMeasure = unit.UnitDescription,
                                Description = prods.Description,
                                TotalPrice = prods.TotalPrice
                            }).FirstOrDefault();

            return product;
        }

        public List<ProductsVM> GetProductList()
        {


            var products = (from prods in _product.GetAll().AsQueryable()
                            join cat in _category.GetAll().AsQueryable() on prods.CategoryId equals cat.BaseId
                            join unit in _unitOfMeasure.GetAll().AsQueryable() on prods.UomId equals unit.BaseId
                            select new ShopCore.Dtos.ProductsVM
                            {
                                ProductId = prods.BaseId,
                                ProductName = prods.ProductName,
                                ProductImg = prods.ProductImg,
                                DiscountPerc = prods.DiscountPerc.GetValueOrDefault(),
                                AvailablelQuantity = prods.AvailablelQuantity,
                                Category = cat.CategoryName,
                                UnitOfMeasure = unit.UnitDescription,
                                Description = prods.Description,
                                TotalPrice = prods.TotalPrice
                            }).ToList();


            return products;
        }

    
    }
}
