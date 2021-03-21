using Microsoft.AspNetCore.Mvc;
using ShopCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    public class OrdersController :BaseApiController
    {
        private readonly IOrderSalesHeader _orderSalesHeader;

        private readonly IOrderSalesDetail _orderSalesDetails;
        public OrdersController(IOrderSalesHeader orderSalesHeader, IOrderSalesDetail orderSalesDetails)
        {
            _orderSalesHeader = orderSalesHeader;
            _orderSalesDetails = orderSalesDetails;
        }
        [HttpGet]
        [Route("GetListOfOrders")]
        public ActionResult<ShopCore.Dtos.OrderSalerHeaderVM> GetListOfOrders(string? customerId)
        {
            var orders = _orderSalesHeader.GetAllInvoices(customerId);

            return Ok(orders);
        }


        [HttpGet]
        [Route("GetListOfOrderDetails")]
        public ActionResult<ShopCore.Dtos.OrderSalesDetailVM> GetListOfOrderDetails(string? orderId)
        {
            var orderDetails = _orderSalesDetails.getOrderDetails(orderId);

            return Ok(orderDetails);
        }


    }
}
