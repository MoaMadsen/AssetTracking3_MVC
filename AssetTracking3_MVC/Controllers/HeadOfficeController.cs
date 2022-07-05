using AssetTracking3_MVC.Data;
using AssetTracking3_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracking3_MVC.Controllers
{
    public class HeadOfficeController : Controller
    {
        ApplicationDbContext Context;
        public HeadOfficeController(ApplicationDbContext c)
        {
            Context = c;
        }
        public IActionResult Index()
        {
            var OfficeList = Context.Offices.ToList();
            return View(OfficeList);
        }

        public IActionResult CreateOffice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOffice(string country, string currency, string rate)
        {
            IdentityRole Role = new();
            Office Office = new();
            // Add office in Office database
            Office.Country = country;
            Office.Currency = currency.ToUpper();
            Office.Rate = Convert.ToDouble(rate);
            Context.Offices.Add(Office);
            Context.SaveChanges();

            // Add role in Role database
            Role.Id = Office.Id.ToString();
            Role.Name = country;
            Role.NormalizedName = country.ToUpper();
            Context.Roles.Add(Role);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateOffice(int? id)
        {
 //           System.Diagnostics.Debug.WriteLine(id);
            Office Office = Context.Offices.FirstOrDefault(f => f.Id == id);
            return View(Office);
        }

        [HttpPost]
        public IActionResult UpdateOffice(int id, string country, string currency, string rate)
        {
            IdentityRole Role = Context.Roles.FirstOrDefault(r => r.Id == id.ToString());
            Office Office = Context.Offices.FirstOrDefault(f => f.Id == id);
            Office.Country = country;
            Office.Currency = currency.ToUpper();
            Office.Rate = Convert.ToDouble(rate);
            Role.Name = country;
            Role.NormalizedName = country.ToUpper();
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteOffice(int? id)
        {
            //           System.Diagnostics.Debug.WriteLine(id);
            Office Office = Context.Offices.FirstOrDefault(f => f.Id == id);
            return View(Office);
        }

        [HttpPost]
        public IActionResult DeleteOffice(int id)
        {
            IdentityRole Role = Context.Roles.FirstOrDefault(r => r.Id == id.ToString());
            Office Office = Context.Offices.FirstOrDefault(f => f.Id == id);
            Context.Remove(Office);
            Context.Remove(Role);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
