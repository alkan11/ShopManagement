using Dapper;
using Shared.Context;
using Shared.Models.Documents;
using Shared.Models.Home;
using Shared.Models.System;
using Shared.Results;
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
				var parameters = new { Uuid = model.Uuid, Filename = model.Filename, Description=model.Description, Status = model.Status, CreatedDate=model.CreatedDate, FolderId=model.FolderId};
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

		public async Task<Folder> FindFolder(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pFindFolder";
				var parameters = new { @id = id };
				var result = await dbConnection.QueryFirstOrDefaultAsync<Folder>(procedure,parameters,commandType: CommandType.StoredProcedure);
				return result;
			}
		}
		public async Task<Files> FindFile(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pFindFile";
				var parameters = new { @id = id };
				var result = await dbConnection.QueryFirstOrDefaultAsync<Files>(procedure,parameters,commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task DeleteFile(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pDeleteFile";
				var parameters = new { @id = id };
				await dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}
		public async Task DeleteFolder(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pDeleteFolder";
				var parameters = new { @id = id };
				await dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}
	}
}
