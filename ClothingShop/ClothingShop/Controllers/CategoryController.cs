using System.Linq;
using System.Web.Mvc;
using ClothingShop.Models;
using ClothingShop.Models.SingletenPattern;

namespace ClothingShop.Controllers
{
    
    public class CategoryController : Controller
    {
        ClothingStoreEntities db = new ClothingStoreEntities();
        // GET: Category
        public ActionResult Index()
        {
            var prodList = db.Products.ToList();
            return View(prodList);
        }

        public ActionResult ListProductCate(int id)
        {
            ViewBag.Category = db.Categories.FirstOrDefault(c => c.CategoryID == id).CategoryName;
            var prodList = db.Products.Where(p => p.CategoryID == id).ToList();
            return View(prodList);
        }
        public ActionResult Search(string inputSearch)
        {
            var result = db.Products.Where(s => s.ProductName.Contains(inputSearch)).ToList();

            return View(result);
        }
    }
}