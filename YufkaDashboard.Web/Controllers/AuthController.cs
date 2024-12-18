using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Auth;
using YufkaDashboard.Business.Abstract;

namespace YufkaDashboard.Web.Controllers
{

	public class AuthController : Controller
	{
		private readonly IAuthBussiness _authBussiness;

		public AuthController(IAuthBussiness authBussiness)
		{
			_authBussiness = authBussiness;
		}

		[HttpGet]

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> SignIn(Users model)
		{
			var result = await _authBussiness.GetAllUsers();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					return View();
				}

				var userApprove = result.Data?.Exists(x => x.UserName == model.UserName && x.Password == model.Password);
				if (userApprove != null && userApprove == true)
				{
					return RedirectToAction("Index","Home");
				}
				else
				{
					TempData["msg"] = "Kullanıcı adı veya şifre hatalıdır. Tekrar deneyin!";
					return RedirectToAction("Index", "Auth");
				}
			}
			return RedirectToAction("Index", "Auth");
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
