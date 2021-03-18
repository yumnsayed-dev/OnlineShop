using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopRepository.ShopContext;
using Microsoft.EntityFrameworkCore;
using ShopCore.Domain;
using ShopServices.ShopRepoServices;
using ShopApi.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ShopApi.Errors;

namespace ShopApi
{
    public class Startup
    {
        private readonly IConfiguration _IConfig;
        public Startup(IConfiguration Config)
        {
            _IConfig = Config;
        }

      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DependacyInjection Services
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryService<>));
            services.AddScoped<IProduct, ProductService>();
            services.AddScoped<IOrderSalesHeader, OrderSalesHeaderService>();
            services.AddScoped<IOrderSalesDetail, OrderSalesDetailService>();
            services.AddScoped<ICategory, CategoryService>();
            services.AddScoped<ITaxTypes, TaxTypesService>();
            services.AddScoped<IUnitOfMeasure, UnitOfMeasureService>();
            services.AddControllers();

            //Passing array of validation error by overriding API BAHVOIR
            // it have to be done after adding 'services.AddControllers()'
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                   .Where(x => x.Value.Errors.Count > 0)
                                   .SelectMany(x => x.Value.Errors)
                                   .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });


            services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer(_IConfig.GetConnectionString("OnlineShoppingCS")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExecptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseHttpsRedirection();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
