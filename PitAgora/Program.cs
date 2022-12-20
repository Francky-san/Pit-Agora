using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PitAgora
{
    public class Programgit
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					if (System.Diagnostics.Debugger.IsAttached)
					{
						Console.WriteLine("Debug mode");
						webBuilder.UseStartup<Startup>();
					}
					else
					{
						Console.WriteLine("Release mode");
						webBuilder.UseStartup<Startup>().UseUrls("http://0.0.0.0:5000", "http://0.0.0.0:5001");
					}
				});
    }
}
