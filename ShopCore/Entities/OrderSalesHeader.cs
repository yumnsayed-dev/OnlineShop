using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopCore.Entities
{
    public class OrderSalesHeader : BaseObject
    {
    

        public DateTime OrderDate { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime OrderDueDate { get; set; }

        public bool StandingOrderStatus { get; set; }

        public int CustomerId { get; set; }

        public int TaxId { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal TaxVal { get; set; }

        public int DiscountId { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal DiscountVal { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal OrderNetVal { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal OrderTotalVal { get; set; }


        //Relations
        [ForeignKey(nameof(TaxId))]
        public TaxTypes TaxTypes { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public OrderDiscountTypes OrderDiscountTypes { get; set; }

    }
}
