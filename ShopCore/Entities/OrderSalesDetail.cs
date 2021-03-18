using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopCore.Entities
{
    public class OrderSalesDetail : BaseObject
    {
  
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int UomId { get; set; }

        public int TaxId { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal TaxVal { get; set; }
        public int ProducDiscountPerc { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal DiscountVal { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalVal { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalNetVal { get; set; }


        //Relations
        [ForeignKey(nameof(OrderId))]
        public OrderSalesHeader OrderSalesHeader { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductsDto Product { get; set; }


      


    }
}
