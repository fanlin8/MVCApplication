using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Models;

namespace MVCApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //var products = from p in GetProductList()
            var products = from p in GetProductListFromDB()
                           orderby p.ID
                           select p;

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id.GetValueOrDefault() == 0)
            {
                return Content("Not a valid Product!!!");
            }
            var product = new Product();

            foreach (var p in GetProductListFromDB())
            {
                if (p.ID == id)
                {
                    product = p;
                    break;
                }
            }
            return View(product);
        }
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Category = "Coat",
                    Name = "MIUCY Green Coat",
                    Detail = "Size: S,M,L." + Environment.NewLine + "Fabric: Cotton",
                    Price = 68.99m,
                    Image = "https://www.pinkqueen.com/upload/thumb/360x540/goodsimport/2014-12/PTC0183GR_1.jpg"
                },
                new Product
                {
                    ID = 2,
                    Category = "Shoe",
                    Name = "MIKASO Red Shoe",
                    Detail = "Material: Patent." + Environment.NewLine + "Heel Height: 3.92\"",
                    Price = 124.99m,
                    Image = "http://www.shoeperwoman.com/wp-content/uploads/2013/05/red-shoes1.jpg"
                },
                new Product
                {
                    ID = 3,
                    Category = "Bag",
                    Name = "ROMI White Bag",
                    Detail = "Material: Genuine Leather." + Environment.NewLine + "Dimension: 6.75\"W*6\"H*3\"D",
                    Price = 259.99m,
                    Image = "https://cdn.shopify.com/s/files/1/1754/9245/products/HU19ESTSA2_STELLA_MINI_SATCHEL_XBODY_129_OPTIC_WHITE_A_grande.jpg?v=1554144227"
                },
                new Product
                {
                    ID = 4,
                    Category = "Jewelry",
                    Name = "ZODC Diamond Ring",
                    Detail = "Center Diamond: round cut." + Environment.NewLine + "Total carat weight: choose of 0.25, 0.5 and more",
                    Price = 1299.99m,
                    Image = "http://venamoris.com/wp-content/uploads/2018/06/RCE-003-P11.jpg"
                },
            };
        }

        [NonAction]
        public List<Product> GetProductListFromDB()
        {
            var productsDB = ProductDataDisplay.productDataDisplay();
            var products = new List<Product>();
            foreach (ProductFromDB pdb in productsDB)
            {
                Product pd = new Product();
                pd.ID = pdb.ID;
                pd.Name = pdb.Name;
                pd.Price = pdb.Price;
                pd.Category = pdb.Category;
                pd.Detail = pdb.Detail;
                pd.Image = pdb.Image;
                pd.Inventory = pdb.Inventory;

                products.Add(pd);
            }
            return products;
        }
    }
}
