using ShopCore.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCore.Domain
{
   public interface IOrderSalesHeader
    {
        List<OrderSalerHeaderVM> GetAllInvoices(string customerId);
        bool InsertOrder(OrderSalerHeaderVM header, List<OrderSalesDetailVM> details);

    }
}
