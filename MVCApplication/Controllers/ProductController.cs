using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = from p in GetProductList()
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
            var inputId = Server.HtmlEncode("ID of selected product is " + id.ToString());
            return Content(inputId);
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
                    Name = "Coat",
                    Detail = "Green Coat",
                    Price = 12.99m
                },
                new Product
                {
                    ID = 2,
                    Name = "Shoe",
                    Detail = "Red Coat",
                    Price = 24.99m
                },
                new Product
                {
                    ID = 2,
                    Name = "Bag",
                    Detail = "White Coat",
                    Price = 59.99m
                },
                new Product
                {
                    ID = 3,
                    Name = "Jewelry",
                    Detail = "Diamond Ring",
                    Price = 1299.99m
                },
            };
        }
    }
}
