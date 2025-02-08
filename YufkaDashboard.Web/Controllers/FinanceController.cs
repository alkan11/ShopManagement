using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Finance;
using System.Reflection;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.Business.Concrete;

namespace YufkaDashboard.Web.Controllers
{
    //[Authorize]
    public class FinanceController : Controller
	{
		private readonly IFinanceBusiness _financeBusiness;

		public FinanceController(IFinanceBusiness financeBusiness)
		{
			_financeBusiness = financeBusiness;
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
		public async Task<IActionResult> MainIncomes()
		{
			var result = await _financeBusiness.GetAllMounthWriteIncome();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}
				ViewBag.Data=result.Data.Where(x => x.CreatedDate.Value.Month == DateTime.Now.Month).ToList(); ;
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
				ViewBag.Data = result.Data.Where(x => x.CreatedDate.Month == DateTime.Now.Month).ToList();
			}
			return View();
		}
		public async Task<IActionResult> MainExpenses()
		{
			var result = await _financeBusiness.GetAllMounthSummerGoes();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}
				ViewBag.Data = result.Data.Where(x=>x.CreatedDate.Month==DateTime.Now.Month).ToList();
			}
			return View();
		}
		public async Task<IActionResult> EndDays()
		{
			decimal mounthSummerGoes = 0, mounthWriteIncome = 0, mainCaseTotal = 0;

			var result = await _financeBusiness.GetAllEndDays();
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return View();
				}
				ViewBag.Data = result.Data;
				mainCaseTotal = result.Data.Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Year == DateTime.Now.Year
														&& x.CreatedDate.HasValue && x.CreatedDate.Value.Month == DateTime.Now.Month).Select(x => x.CashTotal).Sum();
				ViewBag.MainCaseTotal = mainCaseTotal;
				ViewBag.MainCaseCaseDiff = result.Data.Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Year == DateTime.Now.Year
														&& x.CreatedDate.HasValue && x.CreatedDate.Value.Month == DateTime.Now.Month).Select(x => x.CashDiff).Sum();
			}

			var resultMounthSummerGoes=await _financeBusiness.GetAllMounthSummerGoes();
			if (resultMounthSummerGoes != null)
			{
				if (!resultMounthSummerGoes.IsSuccessful)
				{
					TempData["error"] = resultMounthSummerGoes.Message;
					return View();
				}
				mounthSummerGoes = resultMounthSummerGoes.Data.Where(x => x.CreatedDate.Year == DateTime.Now.Year
														&& x.CreatedDate.Month == DateTime.Now.Month).Select(x => x.SummerAmount).Sum();
				ViewBag.MounthSummerGoes = mounthSummerGoes;


			}
			var resultMounthWriteIncome = await _financeBusiness.GetAllMounthWriteIncome();
			if (resultMounthWriteIncome != null)
			{
				if (!resultMounthWriteIncome.IsSuccessful)
				{
					TempData["error"] = resultMounthWriteIncome.Message;
					return View();
				}
				mounthWriteIncome = resultMounthWriteIncome.Data.Where(x => x.CreatedDate.HasValue && x.CreatedDate.Value.Year == DateTime.Now.Year
														&& x.CreatedDate.HasValue && x.CreatedDate.Value.Month == DateTime.Now.Month).Select(x => x.WriteIncomeAmount).Sum();
				ViewBag.MounthWriteIncome = mounthWriteIncome;

			}

			ViewBag.MounthCiro= (mainCaseTotal + mounthWriteIncome) - mounthSummerGoes;
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
		public async Task<IActionResult> AddMainCaseSummerGoes(SummerGoes model)
		{
			if (string.IsNullOrEmpty(model.CreatedDate.ToString())) { model.CreatedDate = DateTime.Now; }

			var result = await _financeBusiness.AddMainCaseSummerGoes(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("EndDays", "Finance");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("MainExpenses", "Finance");
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
		public async Task<IActionResult> AddMainCaseWriteIncome(WriteIncome model)
		{
			if (string.IsNullOrEmpty(model.CreatedDate.ToString())) { model.CreatedDate = DateTime.Now; }

			var result = await _financeBusiness.AddMainCaseWriteIncome(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("EndDays", "Finance");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("MainIncomes", "Finance");
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

		public async Task<IActionResult> EndMounthBuy(EndDay model)
		{
			if (string.IsNullOrEmpty(model.CreatedDate.ToString())) { model.CreatedDate = DateTime.Now; }

			var result = await _financeBusiness.AddEndMounthBuy(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("EndDays", "Finance");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("EndDays", "Finance");
		}
		public async Task<IActionResult> Analysis()
		{
			return View();
		}

		public async Task<JsonResult> ChartDailyEndDay()
		{
			List<object> list = new List<object>();

			var result = await _financeBusiness.ChartDailyEndDay();
			if (result != null)
			{
				foreach (var item in result.Data)
				{
					item.FormattedDate = item.Date.ToShortDateString();

				}
				list.AddRange(result.Data);
			}
			return Json(new { ok = true, data = list });
		}

	}
}
