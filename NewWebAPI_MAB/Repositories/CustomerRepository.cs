using System.Data;
using System.Data.SqlClient;
using NewWebAPI_MAB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NewWebAPI_MAB.Repositories
{
    public class CustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAll Customers
        public IEnumerable<CustomerModel> SelectAll()
        {
            var customers = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_GetAll", conn)
                {

                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new CustomerModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        HomeAddress = reader["HomeAddress"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = reader["MobileNo"].ToString(),
                        CityName = reader["CityName"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        User = new UserModel()
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                        }
                    });
                }
            }
            return customers;
        }
        #endregion
    }
}
