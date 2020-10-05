using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TrendsHairShop.Models;

namespace TrendsHairShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration {get;}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*whenever a class requires any of these times ie IHair and ICategoryRepository,
            they will implemented automatically by the built in dependency injection */
            
            services.AddDbContext<TrendsHairDbContext>(opts => opts.UseMySql
            (Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<TrendsHairDbContext>();

            services.AddScoped<IHairRepository, HairRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<ShoppingCart>(sp =>ShoppingCart.GetCart(sp)); //all interactions of the user in this session will use this shoppingcart (its "scopped")
            services.AddHttpContextAccessor();
            services.AddSession();
            /*  services.AddScoped-- created instance remains active throughout the entire scope. 
                                    When instance goes out of scope, the instance is discarded 
                                    "singleton per a request". good to work with data access models

              services.AddSingleton -- creates a single instance for the entire apln and 
                                        reuse that single instance.
                services.AddTransient -- gives a new instance each time you ask for one*/
                
            services.AddControllersWithViews();
            services.AddRazorPages();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
