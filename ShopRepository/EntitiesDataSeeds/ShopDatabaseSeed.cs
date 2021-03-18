using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShopCore.Entities;
using ShopRepository.ShopContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRepository.EntitiesDataSeeds
{
   public class ShopDatabaseSeed
    {
        public static async Task SeedDatabase(ShopDbContext ShopContext, ILoggerFactory LoggerFactory) 
        {
            try
            {
            

                if (!ShopContext.Category.Any())
                {
                    var categoryData =
                        File.ReadAllText("../ShopRepository/EntitiesDataSeeds/Category.json");
                    var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);

                    foreach (var item in categories)
                    {
                        ShopContext.Category.Add(item);
                    }
                    await ShopContext.SaveChangesAsync();
                }

                if (!ShopContext.OrderDiscountTypes.Any())
                {
                    var orderDiscountData =
                        File.ReadAllText("../ShopRepository/EntitiesDataSeeds/DiscountTypes.json");
                    var orderDiscount = JsonConvert.DeserializeObject<List<OrderDiscountTypes>>(orderDiscountData);

                    foreach (var item in orderDiscount)
                    {
                        ShopContext.OrderDiscountTypes.Add(item);
                    }
                    await ShopContext.SaveChangesAsync();
                }

                if (!ShopContext.TaxTypes.Any())
                {
                    var taxTypesData =
                        File.ReadAllText("../ShopRepository/EntitiesDataSeeds/TaxTypes.json");
                    var taxTypes = JsonConvert.DeserializeObject<List<TaxTypes>>(taxTypesData);

                    foreach (var item in taxTypes)
                    {
                        ShopContext.TaxTypes.Add(item);
                    }
                    await ShopContext.SaveChangesAsync();
                }

                if (!ShopContext.UnitOfMeasure.Any())
                {
                    var UnitOfMeasureData =
                        File.ReadAllText("../ShopRepository/EntitiesDataSeeds/UnitOfMeasure.json");
                    var UnitOfMeasures = JsonConvert.DeserializeObject<List<UnitOfMeasure>>(UnitOfMeasureData);

                    foreach (var item in UnitOfMeasures)
                    {
                        ShopContext.UnitOfMeasure.Add(item);
                    }
                    await ShopContext.SaveChangesAsync();
                }
                if (!ShopContext.Products.Any())
                {
                    var productData =
                        File.ReadAllText("../ShopRepository/EntitiesDataSeeds/Products.json");
                    var products = JsonConvert.DeserializeObject<List<ProductsDto>>(productData);

                    foreach (var item in products)
                    {
                        ShopContext.Products.Add(item);
                    }
                    await ShopContext.SaveChangesAsync();
                }
            }
            catch (Exception ex )
            {
                var logger = LoggerFactory.CreateLogger<ShopDatabaseSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
