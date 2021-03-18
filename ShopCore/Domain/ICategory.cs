using ShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopCore.Domain
{
  public  interface ICategory
    {
        List<Category> GetCategoryList();
    }
}
