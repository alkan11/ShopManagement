using Microsoft.AspNetCore.Mvc;

namespace YufkaDashboard.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
