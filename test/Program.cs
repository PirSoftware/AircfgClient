using Com.Aircfg.Client.Extension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AirCfgTestProject
{
    public class Program
    {
        #region Public Methods

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .AirCfg("603032851a28a7096b95fa0a", "PItjPfvXcjHkXCJ7kA3NhuvKbKGjAHAW")
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        #endregion Public Methods
    }
}