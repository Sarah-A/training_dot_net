using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspDotNetCoreFromScratch
{
    public class Program
    {
        // At its core, this is just a console application that listens to web requests.
        public static void Main(string[] args)
        {
            // Building the web host and start listenning on it.
            CreateWebHostBuilder(args).Build().Run();
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
