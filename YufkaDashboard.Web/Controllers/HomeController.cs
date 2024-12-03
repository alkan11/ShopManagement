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

		public HomeController(ISystemBusiness systemBusiness, IConfiguration configuration, IProductBusiness productBusiness)
		{
			_systemBusiness = systemBusiness;
			_configuration = configuration;
			_productBusiness = productBusiness;
		}

		public async Task<IActionResult> Index()
        {
            var allProducts = await _productBusiness.GetAllProducts();
            var allPaymentType = await _systemBusiness.GetAllStringsByStringGroup("PaymentType");
            ViewBag.AllProducts = allProducts.Data;
            ViewBag.AllPaymentType = allPaymentType.Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(RepeaterFormModel basket)
        {
			foreach (var product in basket.Baskets)
			{
				// Her ürün bilgisine erişim
				Console.WriteLine($"ProductId: {product.ProductId}, Quantity: {product.Amount}, Total: {product.Price}");
			}
			return View();
        }
		[HttpGet]
		public async Task<JsonResult> GetProductPrice(int productId)
		{
			//var result = await _productBusiness.GetProductById(productId); // Ürünü veritabanından al

			//if (!result.IsSuccessful) return Json(new { unitPrice = 0 });

			//var product = result.Data;
			return Json(new { unitPrice = 15 });
		}
		public IActionResult Index2()
        {
            return View();
        }
    }
}
