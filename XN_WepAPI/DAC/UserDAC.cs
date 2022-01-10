using Dapper;
using DataShared;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace XN_WepAPI.DAC
{
    public class UserDAC
    {
        readonly string _connectionString;

        public UserDAC(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public User UserCheck(User user)
        {
            string sqlCommand = "SELECT * FROM User_Master WHERE User_ID = @User_ID AND User_PW = @User_PW";
            using (var connection = new SqlConnection(_connectionString))
            {
                var User = connection.QueryFirstOrDefault<User>(sqlCommand,new { User_ID = user.User_ID, User_PW = user.User_PW});

                return User;
            }
        }

    }
}
