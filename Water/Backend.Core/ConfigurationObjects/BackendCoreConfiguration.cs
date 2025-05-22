using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;

namespace Backend.Core.ConfigurationObjects
{
    internal class BackendCoreConfiguration
    {
        IConfiguration _configurationvalue;

        internal BackendCoreConfiguration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("C:\\Users\\joele\\source\\repos\\Water\\Backend.Core\\AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            _configurationvalue = configuration;
        }

        internal IConfiguration GetConfig()
        {
            return _configurationvalue;
        }
    }
}

