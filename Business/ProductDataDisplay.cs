using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using DataAccess;


namespace Business
{
    public class ProductDataDisplay
    {
        public static List<Product> productDataDisplay()
        {
            ProductDataAccess productData = new ProductDataAccess();
            var productDataList = new List<Product>();
            DataSet productDataSet = new DataSet();

            // 2nd Assignment
            // Retrieve data from DB
            // productDataSet = ProductDataAccess.GetProductDataAccessDBWithConfig();

            // 3nd Assignment
            // Retrieve data from web service
            var productSerivce = new ProductServiceReference.ProductServiceClient();
            productDataSet = productSerivce.GetProductDataAccessDBWithConfig();

            // Convert DataSet into a list of objects
            if (productDataSet.Tables.Count > 0)
            {
                productDataList = productDataSet.Tables[0].AsEnumerable().Select(p => new Product
                {
                    // Mapping
                    ID = Convert.ToInt32(p["ID"]),
                    Name = Convert.ToString(p["Name"]),
                    Price = Convert.ToDecimal(p["Price"]),
                    Category = Convert.ToString(p["Category"]),
                    Detail = Convert.ToString(p["Detail"]),
                    Image = Convert.ToString(p["Image"]),
                    Inventory = Convert.ToInt32(p["Inventory"])
                }).ToList();
            }

            return productDataList;
        }
    }
}
