using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCoreFromScratch
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc();
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

            // will try to map the request to an MVC controller. Using the same MapRoute as in tranditional ASP.Net application
            app.UseMvc( cfg => {
                cfg.MapRoute(name: "Default",
                             template: "/{controller}/{action}/{id?}",
                             defaults: new { controller = "App", action = "Index" });
            });
        }
    }
}
