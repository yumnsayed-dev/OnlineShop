using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopCore.Domain;
using ShopCore.Entities;
using ShopRepository.ShopContext;

namespace ShopServices.ShopRepoServices
{
    public class UnitOfMeasureService : IUnitOfMeasure
    {
        private readonly ShopDbContext _shopContext;
        public UnitOfMeasureService(ShopDbContext shopContext)
        {
            _shopContext = shopContext;
        }
        public async Task<IReadOnlyList<UnitOfMeasure>> GetUnitOfMeasureList()
        {
            return await _shopContext.UnitOfMeasure.ToListAsync();
        }
    }
}
