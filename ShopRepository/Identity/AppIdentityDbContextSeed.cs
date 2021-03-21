using Microsoft.AspNetCore.Identity;
using ShopCore.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepository.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAysnc(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Yumn",
                    Email = "yumnsayed@test.com",
                    UserName= "yumnsayed",
                    Address = new Address
                    {
                        FirstName = "Yumn",
                        LastName = "Sayed",
                        City = "Cairo",
                        Street = "Alf-mskan",
                        Country = "Egypt"

                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
               
            }
        }
    }
}
