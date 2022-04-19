using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Pet_Store_BE.Models;
using Pet_Store_BE;
using Pet_Store_BE.Data;
using Microsoft.AspNetCore;

namespace Pet_Store_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<Pet_Store_BEContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                }
                catch(Exception exp)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exp, "Loi nap du lieu");
                }
            }
            host.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
