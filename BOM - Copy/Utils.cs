using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BOM
{
    public static class Utils
    {
        public static SqlConnection ConnectDB()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            string connectionString = configuration.GetConnectionString("localdb");
            return new SqlConnection(connectionString);
        }
    }
}
