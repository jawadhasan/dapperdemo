using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDemoApp.Runner
{
    public static class Config
    {
        //public static string ConnectionString = @"User ID=postgres;Password=sasa;Host=localhost;Port=5432;Database=registration;";
        public static string ConnectionString = @"User ID=postgres;Password=sasa;Host=localhost;Port=5432;Database=registration;";


        public static string GetRDSConnectionString()
        {
           
            var dbname = "registration";

            if (string.IsNullOrEmpty(dbname)) return null;

            var username = "postgres";
            var password = "sasasasa";
            var hostname = "hexquotedb.cmb1qrijkowb.eu-central-1.rds.amazonaws.com";
            var port = "5432";

            //return "User ID=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";

            return $"User ID={username};Password={password};Host={hostname};Port={5432};Database={dbname};";
        }

    }
}
