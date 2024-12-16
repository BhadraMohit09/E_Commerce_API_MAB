using System.Data;
using System.Data.SqlClient;
using NewWebAPI_MAB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NewWebAPI_MAB.Repositories
{
    public class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAll Orders
        public IEnumerable<OrderModel> SelectAll()
        {
            var orders = new List<OrderModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Order_GetAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new OrderModel
                    {
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        PaymentMode = reader["PaymentMode"].ToString(),
                        TotalAmount = reader["TotalAmount"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["TotalAmount"]),
                        ShippingAddress = reader["ShippingAddress"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Customer = new CustomerModel
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            CustomerName = reader["CustomerName"].ToString(),
                        },
                        User = new UserModel
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                        }
                    });
                }
            }
            return orders;
        }
        #endregion
    }
}
