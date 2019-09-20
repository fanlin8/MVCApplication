using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class ProductDataAccess
    {
        public static DataSet productDataAccessDBWithConfig()
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
            DataSet productDataSet = new DataSet();
            productDataSet.Tables.Add(tb);

            // Clean up
            sqlDataReader.Close();
            sqlCommand.Dispose();
            sqlConnect.Close();

            return productDataSet;
        }
    }
}
