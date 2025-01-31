using Microsoft.AspNetCore.Mvc;

namespace YufkaDashboard.Web.Controllers
{
    public class KitUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
