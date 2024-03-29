using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options =>
            //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
            services.AddControllersWithViews();
            //services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Varsay�lan Route Ayar�
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                //Route ayarlar�

                //endpoints.MapControllerRoute(
                //    name: "home",
                //    pattern: "",
                //    defaults: new { controller = "Home", action = "Index" }
                //    );
                //endpoints.MapControllerRoute(
                //    name: "about",
                //    pattern: "/about",
                //    defaults: new { controller = "Home", action = "About" }
                //    );
                //endpoints.MapControllerRoute(
                //    name: "movies",
                //    pattern: "/movies",
                //    defaults: new { controller = "Home", action = "Movies" }
                //    );
                //endpoints.MapControllerRoute(
                //    name: "movieList",
                //    pattern:"movies/list",
                //    defaults: new {controller = "Movies", action="List" }
                //    );
                //endpoints.MapControllerRoute(
                //    name: "movieList",
                //    pattern: "movies/details",
                //    defaults: new { controller = "Movies", action = "Details" }
                //    );
            });
        }
    }
}
