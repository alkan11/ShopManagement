using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Auth;
using System.Security.Claims;
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

		public IActionResult Index(string returnUrl = null)
		{
			//ViewData["ReturnUrl"] = returnUrl;
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> SignIn(Users model, string returnUrl = null)
		{
			var result = await _authBussiness.GetAllUsers();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
                    return RedirectToAction("Index", "Auth");
                }

				var userApprove = result.Data?.Exists(x => x.UserName == model.UserName && x.Password == model.Password);
				if (userApprove != null && userApprove == true)
				{
					//               var claims = new List<Claim>
					//{
					//	new Claim(ClaimTypes.Name, model.UserName)
					//};
					//               var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					//               var authProperties = new AuthenticationProperties
					//               {
					//                   IsPersistent = true
					//               };
					//await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
					//return !string.IsNullOrEmpty(returnUrl) ? Redirect(returnUrl) : RedirectToAction("Index", "Home");
					return RedirectToAction("Index", "Home");

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
