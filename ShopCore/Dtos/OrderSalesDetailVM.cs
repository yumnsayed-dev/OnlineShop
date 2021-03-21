using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCore.Dtos
{
   public class OrderSalesDetailVM
    {
        public int DetailId { get; set; }
        public int SaleId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string TaxName { get; set; }
        public decimal TaxVal { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal AfterSalePrice { get; set; }
        public int DisccountVal { get; set; }
        public int PurchasedQuantity { get; set; }


    }
}
