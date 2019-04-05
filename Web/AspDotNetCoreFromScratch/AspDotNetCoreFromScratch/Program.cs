using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using AspDotNetCoreFromScratch.Data;

namespace AspDotNetCoreFromScratch
{
    public class Program
    {
        // At its core, this is just a console application that listens to web requests.
        public static void Main(string[] args)
        {
            // Build the web host:
            var host = CreateWebHostBuilder(args).Build();

            RunSeeding(host);

            // Run the host - this will start the 
            host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            // The DutchSeeder requires the DbContext which is a scoped service.
            // Therefore, we have to create a scope in order to get the DutchSeeder
            // Since we're running this outside of the host request (which is when the host
            // automatically creates the scope):
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                // This will get the seeder and try to fulfill all of its dependencies.
                // so we need to make sure that we've added the DutchSeeder to the Startup.services
                // so that is can find it there.
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                seeder.Seed();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)                      // Creates a deafult configuration file that we can use to store our configurations
                .ConfigureAppConfiguration(SetupConfiguration)      // Call our own SetupConfiguration function
                .UseStartup<Startup>();

        private static void SetupConfiguration(WebHostBuilderContext context, IConfigurationBuilder builder)
        {
            // Remove the default configuration options
            builder.Sources.Clear();

            // Create our new json-based configuratoin file.
            // Make it reloadable on change so that we won't have to restart our app every time it changes.            
            builder.AddJsonFile("config.json", false, true)
                    .AddXmlFile("config.xml", true)
                    .AddEnvironmentVariables();
            
        }
    }
}
