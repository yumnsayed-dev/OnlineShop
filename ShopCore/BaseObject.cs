using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopCore
{
    public class BaseObject
    {
        [Key]
        public int BaseId { get; set; }
    }
}
