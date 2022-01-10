using Dapper;
using DataShared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace XN_WepAPI.DAC
{
    public class ItemDAC
    {
        readonly string _connectionString;

        internal ItemDAC(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal IEnumerable<Item> GetItems()
        {
            string sqlCommand = "SELECT * FROM Item_Master";
            using (var connection = new SqlConnection(_connectionString))
            {
                var itemList = connection.Query<Item>(sqlCommand).ToList();

                return itemList;
            }

        }

		internal Bad_Good GetDefactData(Bad_Good input)
		{
            string sql = "[SP_Bad_Habits__ED_Sheeran]";
            var param = new
            {
                SearchDateStart = input.DateStart,
                SearchDateEnd = input.DateEnd,
                SearchItem = input.Item_Code
            };
            using (var connection = new SqlConnection(_connectionString))
			{
                var result = connection.Query<Bad_Good>(sql,param,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (result == null)
                {
                    result = new Bad_Good();
                    result.IsSuccess = false;
                }
                else
                {
                    result.DateStart = input.DateStart;
                    result.DateEnd = input.DateEnd;
                    result.Item_Code = input.Item_Code;
                    result.IsSuccess = true;
                }
                return result;
            }                
		}
	}
}
