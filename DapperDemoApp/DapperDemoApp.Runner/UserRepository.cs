using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace DapperDemoApp.Runner
{
    public class UserRepository
    {
        private readonly IDbConnection _db;

        //ctor
        public UserRepository(string connectionString)
        {
            _db = new NpgsqlConnection(connectionString);
        }


        public List<User> GetAll()
        {
            return _db.Query<User>("SELECT * FROM users").ToList();
        }

        public User Insert(User newUser)
        {
            var sql = @"INSERT INTO users(email,firstname,lastname) 
                        VALUES(@email,@firstname, @lastname) RETURNING id;";//SELECT CAST(SCOPE_IDENTITY() as int) for SQL Server

            var id = _db.Query<int>(sql, newUser).Single();
            newUser.Id = id;
            return newUser;
        }

        public User GetById(int id)
        {
            var sql = @"SELECT * FROM users WHERE id = @id";

            return _db.Query<User>(sql, new { id }).SingleOrDefault();
        }

        public User Update(User user)
        {
            var sql = @"UPDATE users SET 
                        email = @Email, firstname = @FirstName, lastName = @LastName 
                        WHERE id = @Id";
            _db.Execute(sql, user);
            return user;
        }

        public void RemoveById(int id)
        {

            var sql = "DELETE FROM users WHERE id = @Id";
            _db.Execute(sql, new {id});
        }
    }
}
