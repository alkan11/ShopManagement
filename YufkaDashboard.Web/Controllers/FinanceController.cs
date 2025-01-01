using Microsoft.AspNetCore.Mvc;
using Shared.Models.Finance;
using System.Reflection;
using YufkaDashboard.Business.Abstract;

namespace YufkaDashboard.Web.Controllers
{
	public class FinanceController : Controller
	{
		private readonly IFinanceBusiness _financeBusiness;

		public FinanceController(IFinanceBusiness financeBusiness)
		{
			_financeBusiness = financeBusiness;
		}

		public IActionResult Analysis()
		{
			return View();
		}

		public async Task<IActionResult> Incomes()
		{
			var result = await _financeBusiness.GetAllWriteIncome();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}
				ViewBag.Data=result.Data;
			}
			return View();
		}
		public async Task<IActionResult> Expenses()
		{
			var result = await _financeBusiness.GetAllSummerGoes();
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
		public async Task<IActionResult> EndDays()
		{
			var result = await _financeBusiness.GetAllEndDays();
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
		public async Task<IActionResult> AddSummerGoes(SummerGoes model)
		{
			if (string.IsNullOrEmpty(model.CreatedDate.ToString())) { model.CreatedDate = DateTime.Now; }

			var result = await _financeBusiness.AddSummerGoes(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("Index", "Home");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public async Task<IActionResult> AddWriteIncome(WriteIncome model)
		{
			if (string.IsNullOrEmpty(model.CreatedDate.ToString())) { model.CreatedDate = DateTime.Now; }

			var result = await _financeBusiness.AddWriteIncome(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("Index", "Home");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("Index","Home");
		}
		[HttpPost]
		public async Task<IActionResult> AddEndDay(EndDay model)
		{
			if (string.IsNullOrEmpty(model.CreatedDate.ToString())) { model.CreatedDate = DateTime.Now; }

			var result = await _financeBusiness.AddEndDay(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("Index", "Home");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("Index", "Home");
		}

	}
}
