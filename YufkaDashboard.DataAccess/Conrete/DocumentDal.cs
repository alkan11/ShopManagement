using Dapper;
using Shared.Context;
using Shared.Models.Documents;
using Shared.Models.Home;
using Shared.Models.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.DataAccess.Abstract;

namespace YufkaDashboard.DataAccess.Conrete
{
	public class DocumentDal : IDocumentDal
	{
		private readonly Context _context;

		public DocumentDal(Context context)
		{
			_context = context;
		}

		public async Task<AddFolder> AddFolder(AddFolder model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddFolder";
				var parameters = new { CreatedDate = model.CreatedDate, Name = model.Name, Status = model.Status };
				var result = await dbConnection.QueryFirstOrDefaultAsync<AddFolder>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task<Files> AddFile(Files model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddFile";
				var parameters = new { Uuid = model.Uuid, Filename = model.Filename, Status = model.Status, CreatedDate=model.CreatedDate, FolderId=model.FolderId};
				var result = await dbConnection.QueryFirstOrDefaultAsync<Files>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task<List<Files>> GetAllFilesByFolderId(int folderId)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllFilesByFolderId";
				var parameters = new {@id=folderId };
				var result = await dbConnection.QueryAsync<Files>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public async Task<List<Folder>> GetAllFolderMain()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllFolderMain";
				var result = await dbConnection.QueryAsync<Folder>(procedure, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}
	}
}
