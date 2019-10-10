using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class ProductDataAccess
    {
        public static DataSet GetProductDataAccessDBWithConfig(string config)
        {
            DataSet productDataSet = new DataSet();

            if (config == "Qing")
            {
                // Retrieve config string from web.config
                var cfg = ConfigurationManager.ConnectionStrings["aStarDB_Q"].ConnectionString;
                SqlConnection sqlConnect = new SqlConnection(cfg);

                // Open DB connection
                sqlConnect.Open();
                string sql = "Select * from Products";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnect);

                // Retrieve table from the DB
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(sqlDataReader);

                productDataSet.Tables.Add(tb);

                // Clean up
                sqlDataReader.Close();
                sqlCommand.Dispose();
                sqlConnect.Close();
            }
            else if (config == "Fan")
            {
                // Retrieve config string from web.config
                var cfg = ConfigurationManager.ConnectionStrings["aStarDB_L"].ConnectionString;
                MySqlConnection sqlConnect = new MySqlConnection(cfg);

                // Open DB connection
                sqlConnect.Open();
                string sql = "Select * from Products";
                MySqlCommand sqlCommand = new MySqlCommand(sql, sqlConnect);

                // Retrieve table from the DB
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(sqlDataReader);

                productDataSet.Tables.Add(tb);

                // Clean up
                sqlDataReader.Close();
                sqlCommand.Dispose();
                sqlConnect.Close();
            }

            return productDataSet;
        }
    }
}
