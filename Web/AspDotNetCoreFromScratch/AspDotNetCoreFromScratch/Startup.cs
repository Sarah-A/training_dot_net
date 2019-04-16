using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCoreFromScratch.Data;
using AspDotNetCoreFromScratch.Data.Entities;
using AspDotNetCoreFromScratch.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AspDotNetCoreFromScratch
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Identity - by default support only cookie authentication:
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<DutchContext>();

            // Add support for JWT Tokens for the Web API interface:
            services.AddAuthentication()
                    .AddCookie()
                    .AddJwtBearer( cfg =>
                    {
                        // configure the token validation with the same parameters used in the token creation:
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidIssuer = _config["Tokens:Issuer"],
                            ValidAudience = _config["Tokens:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                        };
                    });

            // The AddDbContext actually creates a scoped service that exist for the life of
            // the request:
            services.AddDbContext<DutchContext>( cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("DutchConnection"));
            });

            services.AddAutoMapper();

            services.AddTransient<DutchSeeder>();

            services.AddScoped<IDutchRepository, DutchRepository>();

            services.AddTransient<IMailService, NullMailService>();
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling =
                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // This is where we configure what to do when the app receive web requrests.
        // NOTE: The ORDER in this function MATTERS! This is exactly the order in which the different middlewares will be called 
        // whenever the app receive a new request!!
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // display the full debug output page on unhandled exceptions: 
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
           
            // allow the service to serve static files from the wwwroot folder according to the received URL
            app.UseStaticFiles();
            

            // allow serving Node modules from node_modules directory. 
            app.UseNodeModules(env);

            app.UseAuthentication();

            // will try to map the request to an MVC controller. Using the same MapRoute as in tranditional ASP.Net application
            app.UseMvc( cfg => {
                cfg.MapRoute(name: "Default",
                             template: "/{controller}/{action}/{id?}",
                             defaults: new { controller = "App", action = "Index" });
            });
        }
    }
}
