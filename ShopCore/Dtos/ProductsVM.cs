using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCore.Dtos
{
    public class ProductsVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AvailablelQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int DiscountPerc { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }   
        public string Category { get; set; }
        public string ProductImg { get; set; }
    }
}
