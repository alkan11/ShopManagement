using Microsoft.AspNetCore.Mvc;
using Shared.Models.Products;
using Shared.Models.System;
using System;
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
		public async Task<IActionResult> StringGroupList()
		{
			var result = await _systembusiness.GetAllStringGroupCurrentPage();
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
		public async Task<IActionResult> StringList(int groupId)
		{
			var result = await _systembusiness.GetAllStringListCurrentPage(groupId);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}
				ViewBag.GroupId=groupId;
				ViewBag.Data = result.Data;
			}
			return View();
		}

		[HttpGet]
		public async Task<JsonResult> GetStringById(int id)
		{
			var data = new Strings();

			var result = await _systembusiness.GetStringById(id);
			if (result != null)
			{
				data = result.Data;
				return Json(data);
			}

			return Json(data);
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
					return RedirectToAction("StringList", "System", new { groupId = model.GroupId });
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
						return RedirectToAction("StringList", "System", new{groupId = model.GroupId});
					}
					TempData["success"] = "RecordSuccessfullyCreated";
				}

			}
			
			return RedirectToAction("StringList", "System", new{groupId = model.GroupId});
		}
		[HttpPost]
		public async Task<IActionResult> UpdateString(int id, UpdateString model)
		{
			model.Id = id;
			var result = await _systembusiness.UpdateString(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("StringList","System", new { groupId = model.GroupId });
				}
			}

			return RedirectToAction("StringList", "System", new { groupId = model.GroupId });
		}
		[HttpGet]
		public async Task<JsonResult> DeleteStringRecord(int id)
		{
			bool success = false;
			var result = await _systembusiness.Delete(id);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					return Json(new { ok = success,text=result.Message });
				}
				success = true;
			}

			return Json(new {ok=success});
		}
	}
}
