using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopRepository.ShopContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ShopRepository.EntitiesDataSeeds;
using Microsoft.AspNetCore.Identity;
using ShopCore.identity;
using ShopRepository.Identity;

namespace ShopApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            //Replay Pending Mirgations and CreateDB IF NOT EXITS
            using (var scope = host.Services.CreateScope()) 
            {

                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<ShopDbContext>();
                    await context.Database.MigrateAsync();
                    await ShopDatabaseSeed.SeedDatabase(context, loggerFactory);

                    var userManager = services.GetRequiredService <UserManager<AppUser>>();
                    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                    await identityContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUsersAysnc(userManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An Error occured during Migrations");
                    throw;
                }
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
