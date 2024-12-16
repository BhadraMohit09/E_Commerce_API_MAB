using System.Data;
using System.Data.SqlClient;
using NewWebAPI_MAB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NewWebAPI_MAB.Repositories
{
        public class OrderDetailRepository
        {
            private readonly string _connectionString;

            public OrderDetailRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("ConnectionString");
            }

            #region GetAll Order Details
            public IEnumerable<OrderDetailModel> SelectAll()
            {
                var orderDetails = new List<OrderDetailModel>();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PR_OrderDetail_GetAll", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orderDetails.Add(new OrderDetailModel
                        {
                            OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            Product = new ProductModel 
                            {
                                ProductName = reader["ProductName"].ToString() 
                            },
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            User = new UserModel
                            {
                                UserName = reader["UserName"].ToString() 
                            }
                        });
                    }
                }
                return orderDetails;
            }

            #endregion
        }
}
