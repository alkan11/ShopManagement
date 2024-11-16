using Microsoft.AspNetCore.Mvc;

namespace YufkaDashboard.Web.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult ProductList()
		{
			return View();
		}
	}
}
