using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Npgsql;

namespace DapperDemoApp.Runner
{
    public class AccountRepository
    {
        private readonly IDbConnection _db;

        //ctor
        public AccountRepository(string connectionString)
        {
            this._db = new NpgsqlConnection(connectionString);
        }
    }
}
