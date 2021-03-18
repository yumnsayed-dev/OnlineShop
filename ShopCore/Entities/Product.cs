using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopCore.Entities
{
    public class ProductsDto : BaseObject
    {

        public string ProductName { get; set; }

        public int AvailablelQuantity { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal TotalPrice { get; set; }

        public int?  DiscountPerc { get; set; }

        public int UomId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string ProductImg { get; set; }

        [ForeignKey(nameof(UomId))]
        public UnitOfMeasure UnitOfMeasure { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }



    }
}
