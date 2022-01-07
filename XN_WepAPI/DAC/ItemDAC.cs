using Dapper;
using DataShared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace XN_WepAPI.DAC
{
    public class ItemDAC
    {
        readonly string _connectionString;

        public ItemDAC(string connectionString)
        {
            _connectionString = connectionString;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            string sqlCommand = "SELECT * FROM Item_Master";
            using (var connection = new SqlConnection(_connectionString))
            {
                var itemList = connection.Query<Item>(sqlCommand).ToList();

                return itemList;
            }

        }
    }
}
