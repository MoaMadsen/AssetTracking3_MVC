using Microsoft.AspNetCore.Mvc;
using AssetTracking3_MVC.Models;
using AssetTracking3_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking3_MVC.Controllers
{
    public class AssetsController : Controller
    {
        public ApplicationDbContext Context { get; }
        public AssetsController(ApplicationDbContext c)
        {
            Context = c;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(string description)
        {
            Category Category = new();
            Category.Description = description;
            Context.Categories.Add(Category);
            Context.SaveChanges();
            return RedirectToAction("IndexCategory");
        }
        public IActionResult IndexCategory()
        {
            var CategoryList = Context.Categories.ToList();
            return View(CategoryList); 
        }
        public IActionResult CreateAsset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAsset(int categoryid, int officeId, string brand, string model, double price, DateTime purchasedate, DateTime enddate)
        {
            AssetItem Asset = new();
            Asset.CategoryId = categoryid;
            Asset.OfficeId = officeId;
            Asset.Brand = brand;
            Asset.Model = model;
            Asset.Price = price;
            Asset.PurchaseDate = purchasedate;
            Asset.EndOfLife = enddate;
            Context.Assetitems.Add(Asset);
            Context.SaveChanges();
            return RedirectToAction("IndexAsset");
        }
        public IActionResult IndexAsset()
        {
            var AssetList = Context.Assetitems.Include(x => x.Office).Include(x => x.Category).ToList();
            return View(AssetList);
        }
    }
}
