using System.Data;
using System.Data.SqlClient;
using NewWebAPI_MAB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NewWebAPI_MAB.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        #region GetAll Products
        public IEnumerable<ProductModel> SelectAll()
        {
            var products = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_GetAll", conn)
                {

                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
                        ProductCode = reader["ProductCode"].ToString(),
                        Description = reader["Description"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        User = new UserModel() 
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            UserName = reader["UserName"].ToString(),
                            Email = reader["UserEmail"].ToString(),
                            MobileNo = reader["UserMobileNo"].ToString(),
                        }
                    });
                }
            }
            return products;
        }
        #endregion

        #region SelectByID
        public ProductModel SelectByPK(int productID)

        {
            ProductModel product = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_SelectByPK", conn)

                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ProductID", productID);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new ProductModel
                    {
                        ProductName = reader["ProductName"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
                        ProductCode = reader["ProductCode"].ToString(),
                        Description = reader["Description"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"]),
                    };
                }
            }
            return product;
        }
        #endregion

        #region DeleteData
        public bool Delete(int productID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Delete", conn)

                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ProductID", productID);

                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;
            }
        }
        #endregion

        #region InsertProduct
        public bool Insert(ProductModel product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Insert", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@UserID", product.UserID);

                con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        #endregion

        #region UpdateProduct
        public bool Update(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@UserID", product.UserID);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }

        }

        #endregion
    }
}
