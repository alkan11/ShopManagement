using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Products;
using YufkaDashboard.Business.Abstract;
using YufkaDashboard.Business.Concrete;

namespace YufkaDashboard.Web.Controllers
{

	public class ProductController : Controller
	{
		private readonly IProductBusiness _productBusiness;
		private readonly ISystemBusiness _systemBusiness;


		public ProductController(IProductBusiness productBusiness, ISystemBusiness systemBusiness)
		{
			_productBusiness = productBusiness;
			_systemBusiness = systemBusiness;
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
				var result2 = await _systemBusiness.GetAllStringsByStringGroupActive("SalesUnit");
				ViewBag.SalesUnit = result2.Data;
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
		[HttpGet]
		public async Task<JsonResult> GetProductById(int id)
		{
			var data = new Products();

			var result = await _productBusiness.GetProductById(id);
			if (result != null)
			{
				data = result.Data;
				return Json(data);
			}

			return Json(data);
		}
		[HttpGet]
		public async Task<JsonResult> DeleteStringRecord(int id)
		{
			bool success = false;
			var result = await _productBusiness.Delete(id);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					return Json(new { ok = success, text = result.Message });
				}
				success = true;
			}

			return Json(new { ok = success });
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(Products model)
		{
			var result = await _productBusiness.UpdateProduct(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					TempData["error"] = result.Message;
					return RedirectToAction("ProductList");
				}
			}
			TempData["success"] = "RecordSuccessfullyUpdated";
			return RedirectToAction("ProductList");
		}
		[HttpGet]
		public async Task<JsonResult> DeleteUpdateRecord(int id)
		{
			bool success = false;
			var result = await _productBusiness.Delete(id);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					return Json(new { ok = success, text = result.Message });
				}
				success = true;
			}

			return Json(new { ok = success });
		}
	}
}
