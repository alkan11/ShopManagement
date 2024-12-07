using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace YufkaDashboard.Web.Controllers
{
	public class DocumentsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<JsonResult> AddFolder(string folderName)
		{
			string filePath = @"C:\path\to\your\file.txt";

			// Dosyayı oluşturuyor
			using (FileStream fs = File.Create(filePath))
			{
				// Dosya başarıyla oluşturuldu
				Console.WriteLine("Dosya oluşturuldu: " + filePath);
			}

			return Json(new {ok=true});
		}

	}
}
