using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class ProductManager
{
    private readonly SqlConnection _connection;

    public ProductManager()
    {
        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString);
    }


    public void CreateProduct(string productName, string productValue)
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString))
        {
            connection.Open();

            using (var cmd = new SqlCommand("sp_create", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Produto", SqlDbType.VarChar).Value = productName;
                cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = "R$" + productValue + ",00";

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateProduct(int productId, string productName, string productValue)
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString))
        {
            connection.Open();

            using (var cmd = new SqlCommand("sp_update", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productId;
                cmd.Parameters.Add("@Produto", SqlDbType.VarChar).Value = productName;
                cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = "R$" + productValue + ",00";

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteProduct(int productId)
    {
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString))
        {
            connection.Open();

            using (var cmd = new SqlCommand("sp_delete", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productId;
                cmd.ExecuteNonQuery();
            }
        }
    }
}