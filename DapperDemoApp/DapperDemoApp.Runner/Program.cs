using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;

namespace DapperDemoApp.Runner
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var connection =
                new NpgsqlConnection("User ID=postgres;Password=sasa;Host=localhost;Port=5432;Database=registration;"))
            {
                var result = connection.Query("SELECT * FROM users");

                //SingleRow is enough for field names
                var singleRow = result.Select(x => (IDictionary<string, object>) x).FirstOrDefault();
                var colNames = singleRow.Keys.ToList();
                foreach (var colName in colNames)
                {
                    Console.WriteLine(colName);
                }
            }
        }
    }
}
