using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendsHairShop.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TrendsHairShop.Areas.Identity.IdentityHostingStartup))]
namespace TrendsHairShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TrendsHairShopIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TrendsHairShopIdentityDbContextConnection")));

               // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                   // .AddEntityFrameworkStores<TrendsHairShopIdentityDbContext>();
            });
        }
    }
}