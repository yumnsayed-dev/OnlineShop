using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProductsVM = ShopCore.Dtos.ProductsVM;
namespace ShopCore.Domain
{
   public interface IProduct
    {
        ProductsVM GetProductById(int ProductId);

        List<ProductsVM> GetProductList(string catId,string sort);

    }
}
