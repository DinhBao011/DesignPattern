using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;
using System.IO;
using ClothingShop.Models.BuilderPattern;
using ClothingShop.Models.FacadePatten;

namespace ClothingShop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ClothingStoreEntities db = new ClothingStoreEntities();

        // GET: Admin/Products
        public ActionResult Index(string Search = "")
        {
            if (Search != "")
            {
                var products = db.Products.Include(p => p.Category).Where(x => x.ProductName.ToUpper().Contains(Search.ToUpper()));
                return View(products.ToList());
            }
            else
            {
                var products = db.Products.Include(p => p.Category);
                return View(products.ToList());
            }
        }


        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,CategoryID,ProductName,DecriptionPro,price,ImagePro")]
        ProductViewModel productViewModel, HttpPostedFileBase imageProduct)
        {
            #region Builder
            if (ModelState.IsValid)
            {
                // Create a ProductBuilder instance
                var productBuilder = new ProductBuilder();

                // Set properties using the builder
                productBuilder.SetCategory(productViewModel.CategoryID);
                productBuilder.SetProductName(productViewModel.ProductName);
                productBuilder.SetDescription(productViewModel.Description);
                productBuilder.SetPrice(productViewModel.Price);

                // Set image if available
                if (imageProduct != null)
                {
                    var fileName = Path.GetFileName(imageProduct.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    productBuilder.SetImage(fileName);
                    imageProduct.SaveAs(path);
                }

                // Build the product
                Product product = productBuilder.GetProduct();

                // Add product to database
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", productViewModel.CategoryID);
            return View(productViewModel);
            #endregion
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,CategoryID,ProductName,DecriptionPro,price,ImagePro")] Product product, HttpPostedFileBase imageProduct)
        {
            if (ModelState.IsValid)
            {
                if (imageProduct != null)
                {
                    var fileName = Path.GetFileName(imageProduct.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    product.ImagePro = fileName;
                    imageProduct.SaveAs(path);

                    #region Facade Pattern
                    ProductFacade productFacade = new ProductFacade(fileName, product.ProductID, product.ProductName, product.DecriptionPro, 
                                                                    product.price, product.CategoryID, product.ImagePro);
                    productFacade.ConstructProduct(product);
                    #endregion
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
