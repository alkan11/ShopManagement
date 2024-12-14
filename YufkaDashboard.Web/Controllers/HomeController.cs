using Microsoft.AspNetCore.Mvc;
using Shared.Models.Home;
using System.Reflection;
using YufkaDashboard.Business.Abstract;

namespace YufkaDashboard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration; 
        private readonly ISystemBusiness _systemBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IHomeBusiness _homeBusiness;

		public HomeController(ISystemBusiness systemBusiness, IConfiguration configuration, IProductBusiness productBusiness, IHomeBusiness homeBusiness)
		{
			_systemBusiness = systemBusiness;
			_configuration = configuration;
			_productBusiness = productBusiness;
			_homeBusiness = homeBusiness;
		}

		public async Task<IActionResult> Index()
        {
            var allProducts = await _productBusiness.GetAllProducts();
            var allPaymentType = await _systemBusiness.GetAllStringsByStringGroup("PaymentType");
            ViewBag.AllProducts = allProducts.Data;
            ViewBag.AllPaymentType = allPaymentType.Data;

			var basketList = await _homeBusiness.GetAllBaskets();
			if (basketList != null)
			{
				ViewBag.BasketList = basketList.Data;
			}
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
			return Json(new { unitPrice = product.UnitPrice });
		}
 
		public IActionResult Index2()
        {
            return View();
        }
    }
}
