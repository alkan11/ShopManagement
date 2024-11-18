using Microsoft.AspNetCore.Mvc;
using Shared.Models.Products;
using YufkaDashboard.Business.Abstract;

namespace YufkaDashboard.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductBusiness _productBusiness;

		public ProductController(IProductBusiness productBusiness)
		{
			_productBusiness = productBusiness;
		}

		public IActionResult ProductList()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> AddProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProduct model)
		{
			var result =await _productBusiness.AddProduct(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("ProductList");
				}
			}
			TempData["success"] = "RecordSuccessfullyCreated";
			return RedirectToAction("ProductList");
		}
	}
}
