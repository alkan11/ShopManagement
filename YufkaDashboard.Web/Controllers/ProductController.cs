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

		public  async Task<IActionResult> Index()
		{
			return View();
		}
		public async Task<IActionResult> ProductList()
		{
			var result = await _productBusiness.GetAllProducts();
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
