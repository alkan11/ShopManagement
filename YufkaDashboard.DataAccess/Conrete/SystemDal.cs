using Dapper;
using Shared.Context;
using Shared.Models.Products;
using Shared.Models.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.DataAccess.Abstract;

namespace YufkaDashboard.DataAccess.Conrete
{
	public class SystemDal : ISystemDal
	{
		private readonly Context _context;

		public SystemDal(Context context)
		{
			_context = context;
		}
		public async Task<AddString> AddStringAsync(AddString model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddString";
				var parameters = new { StringGroup = model.StringGroup, StringDescription = model.StringDescription, Value1 = model.Value1, Value2 = model.Value2, Description1 = model.Description1, Description2 = model.Description2 ,
					ParentId=model.ParentId, IsActive=model.IsActive ,
					IsSystem=model.IsSystem,
					IsSystemValue=model.IsSystemValue,
					IsSystemKey=model.IsSystemKey,
					CreatedDate=model.CreatedDate};
				var result = await dbConnection.QueryFirstOrDefaultAsync<AddString>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task<AddStringLocale> AddStringLocaleAsync(AddStringLocale model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddStringLocale";
				var parameters = new
				{
					StringId = model.StringId,
					LangId = model.LangId,
					StringDescription = model.StringDescription,
					Description1 = model.Description1,
					Description2 = model.Description2,
					CreatedDate=model.CreatedDate
				};
				var result = await dbConnection.QueryFirstOrDefaultAsync<AddStringLocale>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task Delete(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string query = @"BEGIN TRANSACTION DELETE Strings WHERE Id = @id COMMIT TRANSACTION
								 BEGIN TRANSACTION DELETE StringLocale WHERE StringId = @id COMMIT TRANSACTION";
				var parameters = new { id };
				await dbConnection.ExecuteAsync(query, parameters, commandType: CommandType.Text);
			}
			
		}

		public Task<List<Strings>> GetAllStrings()
		{
			throw new NotImplementedException();
		}

		public async Task<List<Strings>> GetAllStringsCurrentPage()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllStringsCurrentPage";
				var parameters = new { @langid = 0 };
				var result = await dbConnection.QueryAsync<Strings>(procedure,parameters,commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public async Task<List<Strings>> GetAllGroupDetailList(string groupName)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllGroupDetailList";
				var parameters = new { @groupName = groupName };
				var result = await dbConnection.QueryAsync<Strings>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public async Task<Strings> GetStringById(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetStringById";
				var parameters = new { @id = id };
				var result = await dbConnection.QueryFirstAsync<Strings>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task UpdateString(UpdateString model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "UpdateString";
				var parameters = new
				{
					Id=model.Id,
					StringGroup = model.StringGroup,
					StringDescription = model.StringDescription,
					Value1 = model.Value1,
					Value2 = model.Value2,
					Description1 = model.Description1,
					Description2 = model.Description2,
					ParentId = model.ParentId,
					IsActive = model.IsActive,
					IsSystem = model.IsSystem,
					IsSystemValue = model.IsSystemValue,
					IsSystemKey = model.IsSystemKey,
					CreatedDate = model.CreatedDate
				};
				await dbConnection.QueryFirstOrDefaultAsync<UpdateString>(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task UpdateStringLocale(UpdateStringLocale model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "UpdateStringLocale";
				var parameters = new
				{
					StringId = model.StringId,
					LangId = model.LangId,
					StringDescription = model.StringDescription,
					Description1 = model.Description1,
					Description2 = model.Description2,
					CreatedDate = model.CreatedDate
				};
				await dbConnection.QueryFirstOrDefaultAsync<UpdateStringLocale>(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}
	}
}
