using Microsoft.Extensions.Configuration;
using System;

namespace Mvc_BO.Services
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration(string path, string enviromentName = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if(!String.IsNullOrWhiteSpace(enviromentName))
            {
                builder = builder.AddJsonFile($"appsettings.{enviromentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
