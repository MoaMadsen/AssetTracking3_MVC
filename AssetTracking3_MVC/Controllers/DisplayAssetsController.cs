using AssetTracking3_MVC.Data;
using AssetTracking3_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking3_MVC.Controllers
{
    public class DisplayAssetsController : Controller
    {
        public ApplicationDbContext Context { get; }
        public DisplayAssetsController(ApplicationDbContext c)
        {
            Context = c;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult SortSearchAsset()
        {
            List<AssetItem> AssetList = Context.Assetitems.Include(x => x.Office).Include(x => x.Category).ToList();
            AssetList = AssetList.OrderByDescending(x => x.Id).ToList();
            return View(AssetList);
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.OfficeSortParm = String.IsNullOrEmpty(sortOrder) ? "office_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "Category_desc" : "Category";
            ViewBag.PDateSortParm = sortOrder == "PurchaseDate" ? "PurchaseDate_desc" : "PurchaseDate";
            ViewBag.EDateSortParm = sortOrder == "EndDate" ? "EndDate_desc" : "EndDate";
 
            List<AssetItem> AssetList = Context.Assetitems.Include(x => x.Office).Include(x => x.Category).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                AssetList = AssetList.Where(x => x.Brand.Contains(searchString) || x.Model.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "office_desc":
                    AssetList = AssetList.OrderByDescending(x => x.OfficeId).ToList();
                    break;
                case "Category":
                    AssetList = AssetList.OrderBy(x => x.Office.Country).ToList();
                    break;
                case "Category_desc":
                    AssetList = AssetList.OrderByDescending(x => x.Office.Country).ToList();
                    break;
                case "PurchaseDate":
                    AssetList = AssetList.OrderBy(x => x.PurchaseDate).ToList();
                    break;
                case "PurchaseDate_desc":
                    AssetList = AssetList.OrderByDescending(x => x.PurchaseDate).ToList();
                    break;
                case "EndDate":
                    AssetList = AssetList.OrderBy(x => x.EndOfLife).ToList();
                    break;
                case "End_desc":
                    AssetList = AssetList.OrderByDescending(x => x.EndOfLife).ToList();
                    break;
                default:
                    AssetList = AssetList.OrderBy(x => x.OfficeId).ToList();
                    break;
            }
            return View(AssetList);
        }
    }
}
