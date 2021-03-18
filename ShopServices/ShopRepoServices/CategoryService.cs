using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopCore.Domain;
using ShopCore.Entities;

namespace ShopServices.ShopRepoServices
{
   public class CategoryService : ICategory
    {
        private readonly IRepository<Category> _category;
        public CategoryService( IRepository<Category> category)
        {
            _category = category;
        }

        public List<Category> GetCategoryList()
        {
            return _category.GetAll().AsQueryable().ToList();
        }
    }
}
