using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using shopapp.business.Abstract;
using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;

namespace shopapp.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // mvc
            // razor pages
            //For Product
            services.AddScoped<IProductRepository,EfCoreProductRepository>();
            services.AddScoped<IProductService,ProductManager>();
            //For Category
            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            app.UseStaticFiles(); // It is for wwwroot

             app.UseStaticFiles(new StaticFileOptions
             {
                 FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),RequestPath="/modules"
             });

            if (env.IsDevelopment())
            {   
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
             
            app.UseRouting();

            // localhost:5000
            // localhost:5000/home
            // localhost:5000/home/index
            // localhost:5000/product/details/2
            // localhost:5000/product/list/2
            // localhost:5000/category/list

            app.UseEndpoints(endpoints =>
            {   
                 endpoints.MapControllerRoute(
                    name: "adminproductcreate",
                    pattern:"admin/products/create",
                    defaults: new {controller="Admin",action="CreateProduct"}
                );

                endpoints.MapControllerRoute(
                    name: "adminproductlist",
                    pattern:"admin/panelproducts",
                    defaults: new {controller="Admin",action="PanelProducts"}
                );

                endpoints.MapControllerRoute(
                    name: "adminproductlist",
                    pattern:"admin/panelproducts/{id?}",
                    defaults: new {controller="Admin",action="EditProducts"}
                );
                
                   endpoints.MapControllerRoute(
                    name: "admincategories", 
                    pattern: "admin/categories",
                    defaults: new {controller="Admin",action="CategoryList"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategorycreate", 
                    pattern: "admin/categories/create",
                    defaults: new {controller="Admin",action="CategoryCreate"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategoryedit", 
                    pattern: "admin/categories/{id?}",
                    defaults: new {controller="Admin",action="CategoryEdit"}
                );
               

                 endpoints.MapControllerRoute(
                    name: "search",
                    pattern:"search",
                    defaults: new {controller="shop",action="search"}
                );

                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern:"products/details/{url}",
                    defaults: new {controller="shop",action="details"}
                );

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern:"products/{category?}",
                    defaults: new {controller="shop",action="list"}
                );
                  endpoints.MapControllerRoute(
                     name: "admin",
                    pattern:"admin",
                    defaults: new {controller="Admin",action="PanelHome"}
                     
                 );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
