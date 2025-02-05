using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Home;
using Shared.Models.Products;
using System.Collections.Generic;
using System.Reflection;
using YufkaDashboard.Business.Abstract;

namespace YufkaDashboard.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration; 
        private readonly ISystemBusiness _systemBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IHomeBusiness _homeBusiness;
		private readonly IFinanceBusiness _financeBusiness;

		public HomeController(ISystemBusiness systemBusiness, IConfiguration configuration, IProductBusiness productBusiness, IHomeBusiness homeBusiness, IFinanceBusiness financeBusiness)
		{
			_systemBusiness = systemBusiness;
			_configuration = configuration;
			_productBusiness = productBusiness;
			_homeBusiness = homeBusiness;
			_financeBusiness = financeBusiness;
		}

		public async Task<IActionResult> Index()
        {
			decimal sumTotalPrice=0, writeIncomeAmount=0, summerGoesAmount=0;

			var allProducts = await _productBusiness.GetAllProducts();
            var allPaymentType = await _systemBusiness.GetAllStringsByStringGroupActive("PaymentType");
            ViewBag.AllProducts = allProducts.Data;
            ViewBag.AllPaymentType = allPaymentType.Data;

			var basketList = await _homeBusiness.GetAllBaskets();
			if (basketList != null)
			{
				ViewBag.BasketList = basketList.Data;
			}

			var basketCount=await _homeBusiness.GetDailyBasketCount();
			if (basketCount != null)
			{
				ViewBag.BasketCount=basketCount.Data;
			}

			var dailyBaskets = await _homeBusiness.GetDailyBaskets();
			if (dailyBaskets != null)
			{
				var cashPaymentCount = dailyBaskets.Data?.Where(x => x.PaymentTypeId == 6).Count();
				var creditPaymentCount = dailyBaskets.Data?.Where(x => x.PaymentTypeId == 7).Count();
				var veresPaymentCount = dailyBaskets.Data?.Where(x => x.PaymentTypeId == 8).Count();
				sumTotalPrice = dailyBaskets.Data != null ? dailyBaskets.Data.Sum(x => x.TotalPrice) : 0;

				ViewBag.CashPaymentCount = cashPaymentCount;
				ViewBag.CreditPaymentCount = creditPaymentCount;
				ViewBag.VeresPaymentCount = veresPaymentCount;
				ViewBag.SumTotalPrice = sumTotalPrice;
			}

			var dailySummerGoes = await _financeBusiness.GetDailySummerGoes();
			if (dailySummerGoes != null)
			{
				summerGoesAmount = dailySummerGoes.Data != null ? dailySummerGoes.Data.Sum(x => x.SummerAmount) : 0;
				ViewBag.SummerGoesAmount = summerGoesAmount;
			}

			var dailyWriteIncome = await _financeBusiness.GetDailyWriteIncome();
			if (dailyWriteIncome != null)
			{
				writeIncomeAmount = dailyWriteIncome.Data != null ? dailyWriteIncome.Data.Sum(x => x.WriteIncomeAmount) : 0;
				ViewBag.WriteIncomeAmount = writeIncomeAmount;
			}


			ViewBag.Ciro = (sumTotalPrice + writeIncomeAmount) - summerGoesAmount;

			return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(RepeaterFormModel basket)
        {
			try
			{
				var addBasket = new AddBasket()
				{
					CreatedDate = DateTime.Now,
					TotalPrice = basket.TotalPrice,
					PaymentTypeId = basket.PaymentTypeId,
					Status = 1
				};

				var resultAddBasket = await _homeBusiness.AddBasket(addBasket);
				if (resultAddBasket != null)
				{
					if (!resultAddBasket.IsSuccessful)
					{
						TempData["error"] = resultAddBasket.Message;
						return RedirectToAction("Index");
					}

					foreach (var item in basket.Baskets)
					{
						var addBasketDetail = new AddBasketDetail()
						{
							ProductId = item.ProductId,
							Amount = item.Amount,
							Price = item.Price,
							Status = 1,
							BasketId = resultAddBasket.Data.Id
						};
						var resultAddBasketDetail = await _homeBusiness.AddBasketDetail(addBasketDetail);
						if (resultAddBasketDetail != null)
						{
							if (!resultAddBasketDetail.IsSuccessful)
							{
								TempData["error"] = resultAddBasket.Message;
								return RedirectToAction("Index");
							}
						}
					}



				}
			}
			catch (Exception)
			{

				return Redirect("Index");
			}


			return RedirectToAction("Index");
        }
		[HttpGet]
		public async Task<JsonResult> GetProductPrice(int productId)
		{
			var result = await _productBusiness.GetProductById(productId); // Ürünü veritabanından al

			if (!result.IsSuccessful) return Json(new { unitPrice = 0 });

			var product = result.Data;
			return Json(new { unitPrice = product.UnitPrice,type=product.Type });
		}
		public async Task<JsonResult> DeleteBasketDetail(int id)
		{
			bool success = false;

			var basketRecord=await _homeBusiness.FindBasketDetail(id);
			if (basketRecord != null)
			{
				if (!basketRecord.IsSuccessful)
				{
					return Json(new { ok = success });
				}

				var result = await _homeBusiness.DeleteBasketDetail(id);
				if (result != null)
				{
					if (!result.IsSuccessful)
					{
						return Json(new { ok = success });
					}

					success = true;

					var newBasketTotalPrice =await _homeBusiness.FindBasket(basketRecord.Data.BasketId);
					if(newBasketTotalPrice != null)
					{
						if (!newBasketTotalPrice.IsSuccessful)
						{
							return Json(new { ok = success });
						}

						var newtotalPrice = newBasketTotalPrice.Data.Baskets.Sum(x => x.Price);

						var updatedResult= await _homeBusiness.NewBasketTotalPrice(basketRecord.Data.BasketId, newtotalPrice);
						if (updatedResult != null)
						{
							if (!updatedResult.IsSuccessful)
							{
								return Json(new { ok = success });
							}

							success = true;
						}

					}
				}

			}

			return Json(new { ok = success });
		}
		public async Task<JsonResult> DeleteBasket(int id)
		{
			bool success = false;
			var basketDEtailResult = await _homeBusiness.DeleteBasketDetailByBasketId(id);
			if (basketDEtailResult != null)
			{
				if (!basketDEtailResult.IsSuccessful)
				{
					return Json(new { ok = success,control=1 });
				}

				var result = await _homeBusiness.DeleteBasket(id);
				if (result != null)
				{
					if (!result.IsSuccessful)
					{
						return Json(new { ok = success,control=2 });
					}
					success = true;
				}
			}



			
			return Json(new { ok = success,control=0 });
		}

		

		public async Task<IActionResult> SalesRecords()
        {

			var salesRecord = await _homeBusiness.GetAllSalesRecords();
			if (salesRecord != null)
			{
				ViewBag.SalesRecord = salesRecord.Data;
			}
			return View();
        }

		public async Task<IActionResult> Analysis()
		{
			var result = await _homeBusiness.ChartDailyYufkaCounts();
			if (result != null)
			{
				ViewBag.TotalYufkacount = result.Data.Select(x => x.Amounts).Sum();
			}
			var result2 = await _homeBusiness.ChartDailyMantiKG();
			if (result2 != null)
			{
				ViewBag.TotalMantiKG = result2.Data.Select(x => x.Amount).Sum();
			}
			return View();
		}
		public async Task<JsonResult> ChartDailyYufkaCounts() 
		{
			List<object> list = new List<object>();

			var result = await _homeBusiness.ChartDailyYufkaCounts();
			if (result != null)
			{
				foreach (var item in result.Data)
				{
					item.FormattedDate = item.Date.ToShortDateString();

				}
				list.AddRange(result.Data);
			}
			return Json(new { ok = true ,data=list});
		}
		public async Task<JsonResult> ChartDailyMantiKG() 
		{
			List<object> list = new List<object>();

			var result = await _homeBusiness.ChartDailyMantiKG();
			if (result != null)
			{
				foreach (var item in result.Data)
				{
					item.FormattedDate = item.Date.ToShortDateString();

				}
				list.AddRange(result.Data);
			}
			return Json(new { ok = true ,data=list});
		}
		

	}
}
