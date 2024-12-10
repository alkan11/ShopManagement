using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Shared.Models.Documents;
using System.IO;
using System.Text.Json;
using YufkaDashboard.Business.Abstract;

namespace YufkaDashboard.Web.Controllers
{
	public class DocumentsController : Controller
	{
		private readonly IDocumentBusiness _documentBusiness;

		public DocumentsController(IDocumentBusiness documentBusiness)
		{
			_documentBusiness = documentBusiness;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _documentBusiness.GetAllFolderMain();
			if(result != null) 
			{
				if (result.Data.Any())
				{

					ViewBag.FoldersData = result.Data.OrderByDescending(x => x.CreatedDate).ToList();
				}
			}
			return View();
		}
		[HttpGet]
		public async Task<JsonResult> AddFolder(string folderName)
		{
			bool success = false;
			Shared.Models.Documents.AddFolder model=new Shared.Models.Documents.AddFolder();

			if(!string.IsNullOrEmpty(folderName)) 
			{
				var path = Directory.GetCurrentDirectory();
				string folderPath = $"{path}\\Documents\\{folderName}";

				// Klasör oluştur
				DirectoryInfo folderInfo = Directory.CreateDirectory(folderPath);
				if (folderInfo.Exists)
				{
					success = true;

					model.Name = folderName;
					model.CreatedDate = DateTime.Now;
					model.Status = 1;


					var createdFolder = await _documentBusiness.AddFolder(model);
					if(createdFolder!= null)
					{
						if (!createdFolder.IsSuccessful)
						{
							return Json(new { ok = success,control=1 });
						}

					}
				}

			}
			

			return Json(new {ok=success,control=0});
		}

		[HttpGet]
		public async Task<IActionResult> Files(int folderId)
		{
			var result = await _documentBusiness.GetAllFilesByFolderId(folderId);
			if (result != null)
			{
				if (result.Data.Any())
				{

					ViewBag.FilesData = result.Data.OrderByDescending(x => x.CreatedDate).ToList();
				}
			}
			ViewBag.folderId=folderId;
			return View();
		}
		[HttpGet]
		public async Task<JsonResult> AddFile(string file,int folderId)
		{
			Files model=new Files();
			var decodedFile = Uri.UnescapeDataString(file);
			bool success = false;

			using (JsonDocument doc = JsonDocument.Parse(decodedFile))
			{
				var root = doc.RootElement;

				// JSON içinden değerleri tek tek çek
				model.Uuid = root.GetProperty("uuid").GetString();
				model.Filename = root.GetProperty("filename").GetString(); 

			}

			model.FolderId = folderId;
			model.CreatedDate=DateTime.Now;
			model.Status = 1;

			var result=await _documentBusiness.AddFile(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{

				}

				//var folder= await _documentBusines Find sorgusu yazmak lazım
			}

			//if (!string.IsNullOrEmpty(folderName))
			//{
			//	var path = Directory.GetCurrentDirectory();
			//	string folderPath = $"{path}\\Documents\\{folderName}";

			//	// Klasör oluştur
			//	DirectoryInfo folderInfo = Directory.CreateDirectory(folderPath);
			//	if (folderInfo.Exists)
			//	{
			//		success = true;

			//		model.Name = folderName;
			//		model.CreatedDate = DateTime.Now;
			//		model.Status = 1;


			//		var createdFolder = await _documentBusiness.AddFolder(model);
			//		if (createdFolder != null)
			//		{
			//			if (!createdFolder.IsSuccessful)
			//			{
			//				return Json(new { ok = success, control = 1 });
			//			}

			//		}
			//	}

			//}


			return Json(new { ok = success });
		}
	}
}
