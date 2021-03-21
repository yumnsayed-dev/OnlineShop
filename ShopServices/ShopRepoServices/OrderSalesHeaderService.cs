using ShopCore.Domain;
using ShopCore.Dtos;
using ShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopServices.ShopRepoServices
{
    public class OrderSalesHeaderService : IOrderSalesHeader
    {
        private readonly IRepository<ShopCore.Entities.OrderSalesHeader> _orderSalesHeader;
        private readonly IRepository<ShopCore.Entities.OrderSalesDetail> _orderSalesDetails;
        private readonly IRepository<ShopCore.Entities.ProductsDto> _product;
        private readonly IRepository<Category> _category;
        private readonly IRepository<UnitOfMeasure> _unitOfMeasure;
        private readonly IRepository<TaxTypes> _taxType;
        public OrderSalesHeaderService(IRepository<ShopCore.Entities.OrderSalesHeader> orderSalesHeader, IRepository<TaxTypes> taxType, IRepository<ShopCore.Entities.OrderSalesDetail> orderSalesDetails, IRepository<ShopCore.Entities.ProductsDto> product, IRepository<Category> category,
            IRepository<UnitOfMeasure> unitOfMeasure)
        {

            _orderSalesHeader = orderSalesHeader;
            _orderSalesDetails = orderSalesDetails;
            _product = product;
            _category = category;
            _unitOfMeasure = unitOfMeasure;
            _taxType = taxType;
        }
        public bool InsertOrder(OrderSalerHeaderVM header, List<OrderSalesDetailVM> details) {
            var domainHeader = new OrderSalesHeader();
            var domainDetail = new OrderSalesDetail();
            if (header != null)
            {
                try
                {
                    domainHeader.CustomerId = header.CustomerId;
                    domainHeader.DiscountId = header.OrderNetVal > 5000 ? 5 : 1;
                    domainHeader.OrderNetVal = header.OrderNetVal;
                    domainHeader.OrderTotalVal = header.OrderTotalVal;
                    domainHeader.RequestDate = header.RequestDate;
                    domainHeader.OrderDueDate = header.DueDate;
                    domainHeader.OrderDate = header.OrderDate;
                    domainHeader.TaxId = 1;
                    domainHeader.TaxVal = 14;
                    domainHeader.DiscountVal = 10;
                    domainHeader.StandingOrderStatus = true;
                    _orderSalesHeader.Insert(domainHeader);
                    _orderSalesHeader.SaveChanges();
                    var maxId = _orderSalesHeader.GetMaxId();
                    foreach (var item in details)
                    {
                        domainDetail.DiscountVal = item.DisccountVal;
                        domainDetail.OrderId = maxId;
                        domainDetail.ProductId = item.ProductId;
                        domainDetail.Quantity = item.PurchasedQuantity;
                        domainDetail.TaxId = 1;
                        domainDetail.TaxVal = 14;
                        domainDetail.UomId = item.UnitOfMeasureId;
                        domainDetail.TotalNetVal = item.AfterSalePrice;
                        domainDetail.TotalVal = item.ProductPrice;

                        _orderSalesDetails.Insert(domainDetail);
                        _orderSalesDetails.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    
                }
                


            }
            return false;
        }
        public List<OrderSalerHeaderVM> GetAllInvoices(string? customerId)
        {
            var orders = new List<OrderSalerHeaderVM>();
            if (customerId != null)
            {
                int tempVal;
                int? val = Int32.TryParse(customerId, out tempVal) ? Int32.Parse(customerId) : (int?)null;
                orders = (from header in _orderSalesHeader.GetAll().AsQueryable().Where(x => x.CustomerId == val)
                          join tax in _taxType.GetAll().AsQueryable() on header.TaxId equals tax.BaseId
                          select new OrderSalerHeaderVM
                          {
                              CustomerId = header.CustomerId,
                              CustomerName = "Yumn",
                              DueDate = header.OrderDueDate,
                              OrderDate = header.OrderDate,
                              OrderDiscountVal = header.DiscountVal,
                              OrderNetVal = header.OrderNetVal,
                              OrderStatus = header.StandingOrderStatus == true ? "Pending" : "Closed",
                              OrderTotalVal = header.OrderTotalVal,
                              RequestDate = header.RequestDate,
                              SaleId = header.BaseId,
                              TaxName = tax.TaxName,
                              TaxVal = tax.TaxPerc,
                               OrderDetails = (from detail in _orderSalesDetails.GetAll().AsQueryable().Where(x => x.OrderId == header.BaseId)
                                                 join product in _product.GetAll().AsQueryable() on detail.ProductId equals product.BaseId
                                                 join cat in _category.GetAll().AsQueryable() on product.CategoryId equals cat.BaseId
                                                 join taxs in _taxType.GetAll().AsQueryable() on detail.TaxId equals tax.BaseId
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
                                                     SaleId = header.BaseId,
                                                     TaxName = tax.TaxName,
                                                     TaxVal = tax.TaxPerc,
                                                     UnitOfMeasureName = unit.UnitDescription,
                                                     UnitOfMeasureId = unit.BaseId


                                                 }).ToList()
                          }).OrderBy(x=>x.SaleId).ToList();

            }
            else {
                orders = (from header in _orderSalesHeader.GetAll().AsQueryable()
                          join tax in _taxType.GetAll().AsQueryable() on header.TaxId equals tax.BaseId
                          
                          select new OrderSalerHeaderVM
                          {
                              CustomerId = header.CustomerId,
                              CustomerName = "Yumn",
                              DueDate = header.OrderDueDate,
                              OrderDate = header.OrderDate,
                              OrderDiscountVal = header.DiscountVal,
                              OrderNetVal = header.OrderNetVal,
                              OrderStatus = header.StandingOrderStatus == true ? "Pending" : "Closed",
                              OrderTotalVal = header.OrderTotalVal,
                              RequestDate = header.RequestDate,
                              SaleId = header.BaseId,
                              TaxName = tax.TaxName,
                              TaxVal = tax.TaxPerc,
                              OrderDetails = (from detail in _orderSalesDetails.GetAll().AsQueryable().Where(x => x.OrderId == header.BaseId)
                                              join product in _product.GetAll().AsQueryable() on detail.ProductId equals product.BaseId
                                              join cat in _category.GetAll().AsQueryable() on product.CategoryId equals cat.BaseId
                                              join taxs in _taxType.GetAll().AsQueryable() on detail.TaxId equals tax.BaseId
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
                                                  SaleId = header.BaseId,
                                                  TaxName = tax.TaxName,
                                                  TaxVal = tax.TaxPerc,
                                                  UnitOfMeasureName = unit.UnitDescription,
                                                  UnitOfMeasureId = unit.BaseId


                                              }).ToList()
                          }).OrderBy(x => x.SaleId).ToList();
            }
            return orders;
            
        }
     
    }
}
