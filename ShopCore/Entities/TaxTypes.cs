using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopCore.Entities
{
    public class TaxTypes : BaseObject
    {
 
        public string TaxName { get; set; }

        public int TaxPerc { get; set; }
    }
}
