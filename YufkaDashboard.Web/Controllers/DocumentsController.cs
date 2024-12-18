using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Shared.Models.Documents;
using System.IO;
using System.Reflection;
using System.Text.Json;
using YufkaDashboard.Business.Abstract;
using static NuGet.Packaging.PackagingConstants;

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
				string folderPath = $"{path}\\wwwroot\\Documents\\{folderName}";

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
		[HttpPost]
		public async Task<IActionResult> AddFile(IFormFile file,int folderId,Files model)
		{

			model.Uuid = Guid.NewGuid().ToString();
			model.Filename = file.FileName;
			model.FolderId = folderId;
			model.CreatedDate=DateTime.Now;
			model.Status = 1;

			var result=await _documentBusiness.AddFile(model);
			if (result != null)
			{
				if (!result.IsSuccessful)
				{
					return View();
				}



				var folder = await _documentBusiness.FindFolder(folderId);
				if (folder != null)
				{
					if (!folder.IsSuccessful)
					{
						return View();
					}

					if (folder.Data != null)
					{
						if (!string.IsNullOrEmpty(folder.Data.Name))
						{
							var path = Directory.GetCurrentDirectory();
							string folderPath = $"{path}\\wwwroot\\Documents\\{folder.Data.Name}\\{model.Filename}";

							if (file != null && file.Length > 0)
							{
								using (var stream = new FileStream(folderPath, FileMode.Create))
								{
									file.CopyTo(stream);
								}
							}

						}
					}
					

				}
			}

			return RedirectToAction("Files", "Documents", new { folderId=folderId});
		}

		public async Task<JsonResult> DeleteFile(int id)
		{
			int control = 0;
			var filerecord=await _documentBusiness.FindFile(id);
			if (filerecord != null)
			{
				if (!filerecord.IsSuccessful)
				{
					return Json(new { ok = false,control=1 });
				}

				if (filerecord.Data!=null)
				{
					var result=await _documentBusiness.DeleteFile(id);
					if(result != null)
					{
						if (!result.IsSuccessful)
						{
							return Json(new { ok = false,control=2 });
						}
						var path = Directory.GetCurrentDirectory();
						string folderPath = $"{path}\\wwwroot\\Documents\\{filerecord.Data.FolderName}\\{filerecord.Data.Filename}";

						if (System.IO.File.Exists(folderPath))
						{
							System.IO.File.Delete(folderPath);
						}
					}
				}
			}
			return Json(new { ok = true,control=control });
		}
		public async Task<JsonResult> DeleteFolder(int id)
		{
			int control = 0;
			var folderRecord = await _documentBusiness.FindFolder(id);
			if (folderRecord != null)
			{
				if (!folderRecord.IsSuccessful)
				{
					return Json(new { ok = false, control = 1 });
				}

				if (folderRecord.Data != null)
				{
					var result = await _documentBusiness.DeleteFolder(id);
					if (result != null)
					{
						if (!result.IsSuccessful)
						{
							return Json(new { ok = false, control = 2 });
						}
						var path = Directory.GetCurrentDirectory();
						string folderPath = $"{path}\\wwwroot\\Documents\\{folderRecord.Data.Name}";

						if (Directory.Exists(folderPath))
						{
							Directory.Delete(folderPath, recursive: true);
						}
					}
				}
			}
			return Json(new { ok = true, control = control });
		}
	}
}
