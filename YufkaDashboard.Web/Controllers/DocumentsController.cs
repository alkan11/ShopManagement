using Microsoft.AspNetCore.Mvc;

namespace YufkaDashboard.Web.Controllers
{
	public class DocumentsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
