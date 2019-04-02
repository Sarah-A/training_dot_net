using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCoreFromScratch
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // This is where we configure what to do when the app receive web requrests.
        // NOTE: The ORDER in this function MATTERS! This is exactly the order in which the different middlewares will be called 
        // whenever the app receive a new request!!
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // If the path in the URL doesn't contain a file's name, it will search for default file names e.g. index.html
            // in the path and update the path to include them so localhost will become localhost/index.html
            app.UseDefaultFiles();

            // allow the service to serve static files from the wwwroot folder according to the received URL
            app.UseStaticFiles();
        }
    }
}
