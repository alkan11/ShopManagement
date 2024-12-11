using Shared.Models.Documents;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.Business.Abstract
{
	public interface IDocumentBusiness
	{
		public Task<Response<AddFolder>> AddFolder(AddFolder model);
		public Task<Response<Files>> AddFile(Files model);
		public Task<Response<Folder>> FindFolder(int id);
		public Task<Response<List<Folder>>> GetAllFolderMain();
		public Task<Response<List<Files>>> GetAllFilesByFolderId(int folderId);
	}
}
