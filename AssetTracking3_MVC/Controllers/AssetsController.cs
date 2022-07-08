using Microsoft.AspNetCore.Mvc;
using AssetTracking3_MVC.Models;
using AssetTracking3_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AssetTracking3_MVC.Controllers
{
    public class AssetsController : Controller
    {
        public ApplicationDbContext Context { get; }
        public AssetsController(ApplicationDbContext c)
        {
            Context = c;
        }
        [Authorize]
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
        public IActionResult UpdateCategory(int? id)
        {
            Category Category = Context.Categories.FirstOrDefault(c => c.Id == id);
            return View(Category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(int id, string description)
        {
            Category Category = Context.Categories.FirstOrDefault(c => c.Id == id);
            Category.Description = description;
            Context.SaveChanges();
            return RedirectToAction("IndexCategory");
        }
        [Authorize(Roles ="USA")]
        public IActionResult DeleteCategory(int? id)
        {
            //           System.Diagnostics.Debug.WriteLine(id);
            Category Category = Context.Categories.FirstOrDefault(c => c.Id == id);
            return View(Category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            Category Category = Context.Categories.FirstOrDefault(c => c.Id == id);
            Context.Remove(Category);
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
            ViewData["OfficeId"] = new SelectList(Context.Offices, "Id", "Country");
            ViewData["CategoryId"] = new SelectList(Context.Categories, "Id", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult CreateAsset(int categoryid, int officeId, string brand, string model, double price, DateTime purchasedate)
        {
            AssetItem Asset = new();
            Asset.CategoryId = categoryid;
            Asset.OfficeId = officeId;
            Asset.Brand = brand;
            Asset.Model = model;
            Asset.Price = price;
            Asset.PurchaseDate = purchasedate;
            Asset.EndOfLife = purchasedate.AddYears(3);
            Context.Assetitems.Add(Asset);
            Context.SaveChanges();
            return RedirectToAction("IndexAsset");
        }
        public IActionResult IndexAsset()
        {
            List<AssetItem> AssetList = Context.Assetitems.Include(x => x.Office).Include(x => x.Category).ToList();
 
            AssetList = AssetList.OrderByDescending(x => x.Id).ToList();
            return View(AssetList);
        }

        public IActionResult UpdateAsset(int? id)
        {
            ViewData["OfficeId"] = new SelectList(Context.Offices, "Id", "Country");
            ViewData["CategoryId"] = new SelectList(Context.Categories, "Id", "Description");
            AssetItem Asset = Context.Assetitems.FirstOrDefault(a => a.Id == id);
            return View(Asset);
        }

        [HttpPost]
        public IActionResult UpdateAsset(int id, int categoryid, int officeId, string brand, string model, double price, DateTime purchasedate, DateTime enddate)
        {
            AssetItem Asset = Context.Assetitems.Include(x => x.Office).Include(x => x.Category).FirstOrDefault(a => a.Id == id);
            Asset.CategoryId = categoryid;
            Asset.OfficeId = officeId;
            Asset.Brand = brand;
            Asset.Model = model;
            Asset.Price = price;
            Asset.PurchaseDate = purchasedate;
            Asset.EndOfLife = enddate; 
            Context.SaveChanges();
            return RedirectToAction("IndexAsset");
        }
        public IActionResult DeleteAsset(int? id)
        {
            //           System.Diagnostics.Debug.WriteLine(id);
            //ViewData["OfficeId"] = new SelectList(Context.Offices, "Id", "Country");
            //ViewData["CategoryId"] = new SelectList(Context.Categories, "Id", "Description");
            AssetItem Asset = Context.Assetitems.Include(x => x.Office).Include(x => x.Category).FirstOrDefault(a => a.Id == id);
            return View(Asset);
        }

        [HttpPost]
        public IActionResult DeleteAsset(int id)
        {
            AssetItem Asset = Context.Assetitems.FirstOrDefault(a => a.Id == id);
            Context.Remove(Asset);
            Context.SaveChanges();
            return RedirectToAction("IndexAsset");
        }
    }
}
