using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SuiviDesVols.Layers.Data;
using SuiviDesVols.Layers.DatabaseContexts;
using SuiviDesVols.Layers.Repository.Abstractions;
using SuiviDesVols.Layers.Repository.Implements;

namespace SuiviDesVols
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<LigneVol>, LigneVolRepository>();
            services.AddScoped<IGenericRepository<Aeroport>, AirportRepository>();
            services.AddScoped<IGenericRepository<VolOption>, VolOptionRepository>();
            services.AddScoped<IGenericRepository<Vol>, VolRepository>();


            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "Flights"));

            // AddIdentity : Register the services  
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                                                              .AddDefaultTokenProviders();

            // Cookie settings   
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "FlightBookingCookie";
                config.LoginPath = "/Home/Login";
                config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });

            //Service to user MVC mechanism on the app
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
                app.UseStatusCodePagesWithRedirects("/Error/Index");
            }

            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Flights}/{action=Index}/{id?}");
            });
        }
    }
}
