using Microsoft.AspNetCore.Mvc;

namespace AssetTracking3_MVC.Controllers
{
    public class DisplayAssetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
