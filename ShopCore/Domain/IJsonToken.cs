using ShopCore.identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCore.Domain
{
  public  interface IJsonToken
    {
        string CreateToken(AppUser user);
    }
}
