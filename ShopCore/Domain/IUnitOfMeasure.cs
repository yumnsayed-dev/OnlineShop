using ShopCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Domain
{
    public interface IUnitOfMeasure
    {
        Task<IReadOnlyList<UnitOfMeasure>> GetUnitOfMeasureList();
    }
}
