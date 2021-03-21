using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopCore.Dtos
{
    public class OrderSalerHeaderVM
    {
        public int SaleId { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RequestDate { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueDate { set; get; }

        public string OrderStatus { set; get; }

        public int CustomerId { set; get; }

        public string CustomerName { set; get; }

        public decimal TaxVal { set; get; }

        public string TaxName { set; get; }

        public decimal OrderDiscountVal { set; get; }

        public decimal OrderNetVal { set; get; }

        public decimal OrderTotalVal { set; get; }

        public List<OrderSalesDetailVM> OrderDetails { set; get; }

    }
}
