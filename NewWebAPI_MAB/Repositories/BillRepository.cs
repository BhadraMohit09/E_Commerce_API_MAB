using System.Data;
using System.Data.SqlClient;
using NewWebAPI_MAB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NewWebAPI_MAB.Repositories
{
    public class BillRepository
    {
        private readonly string _connectionString;

        public BillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAll Bills
        public IEnumerable<BillModel> SelectAll()
        {
            var bills = new List<BillModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Bill_GetAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bills.Add(new BillModel
                    {
                        BillID = Convert.ToInt32(reader["BillID"]),
                        BillNumber = reader["BillNumber"].ToString(),
                        BillDate = Convert.ToDateTime(reader["BillDate"]),
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        Order = new OrderModel() // Assuming you have mapped OrderModel to OrderID
                        {
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        },
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        Discount = reader["Discount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Discount"]),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        User = new UserModel() 
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                        }
                    });
                }
            }
            return bills;
        }
        #endregion
    }
}
