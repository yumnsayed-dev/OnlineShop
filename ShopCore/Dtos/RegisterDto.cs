using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCore.Dtos
{
   public class RegisterDto
    {
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
