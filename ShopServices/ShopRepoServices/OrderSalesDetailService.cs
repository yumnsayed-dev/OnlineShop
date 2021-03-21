using ShopCore.Domain;
using ShopCore.Dtos;
using ShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopServices.ShopRepoServices
{
    public class OrderSalesDetailService : IOrderSalesDetail
    {
        private readonly IRepository<ShopCore.Entities.OrderSalesHeader> _orderSalesHeader;
        private readonly IRepository<ShopCore.Entities.OrderSalesDetail> _orderSalesDetails;
        private readonly IRepository<ShopCore.Entities.ProductsDto> _product;
        private readonly IRepository<Category> _category;
        private readonly IRepository<UnitOfMeasure> _unitOfMeasure;
        private readonly IRepository<TaxTypes> _taxType;
        public OrderSalesDetailService(IRepository<ShopCore.Entities.OrderSalesDetail> orderSalesDetails,
            IRepository<ShopCore.Entities.OrderSalesHeader> orderSalesHeader,
            IRepository<ShopCore.Entities.ProductsDto> product, IRepository<Category> category,
            IRepository<UnitOfMeasure> unitOfMeasure,
            IRepository<TaxTypes> taxType) 
        {
            _orderSalesHeader = orderSalesHeader;
            _orderSalesDetails = orderSalesDetails;
            _product = product;
            _category = category;
            _unitOfMeasure = unitOfMeasure;
            _taxType = taxType;
        }

        public List<OrderSalesDetailVM> getOrderDetails(string? OrderId) {
            var details = new List<OrderSalesDetailVM>();
            if (OrderId != null)
            {
                int tempVal;
                int? val = Int32.TryParse(OrderId, out tempVal) ? Int32.Parse(OrderId) : (int?)null;
                 details = (from detail in _orderSalesDetails.GetAll().AsQueryable().Where(x => x.OrderId == val)
                               join product in _product.GetAll().AsQueryable() on detail.ProductId equals product.BaseId
                               join cat in _category.GetAll().AsQueryable() on product.CategoryId equals cat.BaseId
                               join tax in _taxType.GetAll().AsQueryable() on detail.TaxId equals tax.BaseId
                               join unit in _unitOfMeasure.GetAll().AsQueryable() on product.UomId equals unit.BaseId
                               select new OrderSalesDetailVM
                               {
                                   AfterSalePrice = detail.TotalNetVal,
                                   DetailId = detail.BaseId,
                                   ProductId = product.BaseId,
                                   ProductName = product.ProductName,
                                   DisccountVal = product.DiscountPerc.GetValueOrDefault(),
                                   ProductPrice = product.TotalPrice,
                                   PurchasedQuantity = detail.Quantity,
                                   SaleId = detail.OrderId,
                                   TaxName = tax.TaxName,
                                   TaxVal = tax.TaxPerc,
                                   UnitOfMeasureName = unit.UnitDescription,
                                   UnitOfMeasureId = unit.BaseId

                               }).ToList();
            }
            


            return details;
        }
    }
}
