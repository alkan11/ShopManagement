using Shared.Context;
using Shared.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
	public interface IDocumentDal
	{
		public Task<AddFolder> AddFolder(AddFolder model);
		public Task<Files> AddFile(Files model);
		public Task<Folder> FindFolder(int id);
		public Task<List<Folder>> GetAllFolderMain();
		public Task<List<Files>> GetAllFilesByFolderId(int folderId);
	}
}
