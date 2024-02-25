﻿using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Infrastructure.Data
{
    public class EaconomyDBReadContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public EaconomyDBReadContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("EaconomyDBConnection");
        }
        public IDbConnection CreateConnection()
            => new SqliteConnection(_connectionString);
    }
}
