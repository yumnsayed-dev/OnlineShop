using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopCore.Entities
{
   public class OrderDiscountTypes : BaseObject
    {

        public string DiscountName { get; set; }

        public int DiscountPerc { get; set; }
    }
}
