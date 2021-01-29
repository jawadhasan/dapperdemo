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

            var userRepo = new UserRepository(Config.ConnectionString);


            //uncomment following link to Insert Data
            //var newUser = new User
            //{
            //    Email = "heisenberg@breakingbad.com",
            //    FirstName = "Walter",
            //    LastName = "White"
            //};

            //var insertedUser = userRepo.Insert(newUser);


            //Get by Id
            //var user = userRepo.GetById(5);
            // user.FormatOutPut();


            ////Updating Data
            //user.FirstName = "updated";
            //userRepo.Update(user);



            //Delete Data
            //userRepo.RemoveById(5);


            //GetAll
            userRepo.GetAll().FormatOutPut();

        }




        public static void QuickTest()
        {
            using (var connection =
                new NpgsqlConnection("User ID=postgres;Password=sasa;Host=localhost;Port=5432;Database=registration;"))
            {
                var result = connection.Query("SELECT * FROM users").ToList();
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("---------------------------");
                Console.WriteLine();
                Console.WriteLine("Column Names");
                //SingleRow is enough for field names
                var singleRow = result.Select(x => (IDictionary<string, object>)x).FirstOrDefault();
                var colNames = singleRow?.Keys.ToList() ?? new List<string>();
                foreach (var colName in colNames)
                {
                    Console.WriteLine(colName);
                }
            }
        }
    }
}
