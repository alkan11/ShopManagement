using Microsoft.AspNetCore.Mvc;
using Shared.Models.Products;
using Shared.Models.System;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.Business.Concrete;

namespace YufkaDashboard.Web.Controllers
{
	public class SystemController : Controller
	{
		private ISystemBusiness _systembusiness;

		public SystemController(ISystemBusiness systembusiness)
		{
			_systembusiness = systembusiness;
		}

		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> StringList()
		{
			var result = await _systembusiness.GetAllStringsCurrentPage();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}

				var stringData = result.Data;
				ViewBag.Data = stringData.DistinctBy(x => x.StringGroup).ToList();
			}
			return View();
		}
		public async Task<IActionResult> GroupDetailList(string groupName)
		{
			var result = await _systembusiness.GetAllGroupDetailList(groupName);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}

				ViewBag.Data = result.Data;
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddString(AddString model)
		{
			var result = await _systembusiness.AddStringAsync(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("StringList");
				}
				AddStringLocale modelLocale = new AddStringLocale()
				{
					StringId= result.Data.Id,
					StringDescription= result.Data.StringDescription,
					LangId=0,
					Description1 = result.Data.Description1,
					Description2 = result.Data.Description2,
					CreatedDate=result.Data.CreatedDate
					
				};

				var resultLocale = await _systembusiness.AddStringLocaleAsync(modelLocale);
				if (resultLocale != null)
				{
					if (!resultLocale.IsSuccessful)
					{
						TempData["error"] = resultLocale.Message;
						return RedirectToAction("StringList");
					}
					TempData["success"] = "RecordSuccessfullyCreated";
				}

			}
			
			return RedirectToAction("StringList");
		}
	}
}
