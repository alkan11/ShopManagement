using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YufkaDashboard.Web.Controllers
{
    //[Authorize]
    public class KitUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
