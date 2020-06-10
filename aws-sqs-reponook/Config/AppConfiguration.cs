using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AWSQueueReponook.Exceptions;


namespace AWSQueueReponook.Config
{
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _configuration;
        public AppConfiguration()              // ctor
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();         // IMPORTANT!   allows reading out of the local (not uploaded) launchSettings.json for Docker
                _configuration = configBuilder.Build();
        }


        public string AtlasMongoConnection
        {
            get
            {
                string connectionString = _configuration["AtlasMongoConnection"];
                if (connectionString is null) throw new ConfigFileReadError("Check appsettings.json; AtlasMongoConnection not found.");
                return connectionString;
            }
        }
        public string AWSQueueURI
        {
            get
            {
                string connectionString = _configuration["AWSQueueURI"];
                if (connectionString is null) throw new ConfigFileReadError("Check appsettings.json; AWSQueueURI not found.");
                return connectionString;
            }
        }
        public string AWSRegion
        {
            get
            {
                string connectionString = _configuration["AWSRegion"];
                if (connectionString is null) throw new ConfigFileReadError("Check appsettings.json; AWSRegion not found.");
                return connectionString;
            }
        }
        public string AWSAccessKey
        {
            get
            {
                string connectionString = _configuration["AWSAccessKey"];
                if (connectionString is null) throw new ConfigFileReadError("Check appsettings.json; AWSAccessKey not found.");
                return connectionString;
            }
        }
        public string AWSSecretKey
        {
            get
            {
                string connectionString = _configuration["AWSSecretKey"];
                if (connectionString is null) throw new ConfigFileReadError("Check appsettings.json; AWSSecretKey not found.");
                return connectionString;
            }
        }
    }
}
