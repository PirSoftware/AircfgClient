using Com.Aircfg.Client.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Com.Aircfg.Client.Extension
{
    public static class HostBuilderExentison
    {
        #region Public Methods

        public static IHostBuilder AirCfg(this IHostBuilder hostBuilder, string aircfgId, string aircfgKey, string domain = "https://www.aircfg.com", Action<HostBuilderContext, IConfigurationBuilder> configureDelegate = null)
        {
            hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: false)
                    .AddJsonStream(ConfigManager.GetConfig(aircfgId, aircfgKey, domain))
                    .AddEnvironmentVariables();

                if (configureDelegate != null)
                    configureDelegate.Invoke(hostingContext, config);
            });

            return hostBuilder;
        }

        #endregion Public Methods
    }
}