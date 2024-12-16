using Microsoft.AspNetCore.Mvc;

namespace YufkaDashboard.Web.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult SignIn()
		{
			return View();
		}
	}
}
