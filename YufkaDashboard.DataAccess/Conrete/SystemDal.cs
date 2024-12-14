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
using System.Text.RegularExpressions;
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
				var parameters = new { GroupId = model.GroupId, StringDescription = model.StringDescription, Value1 = model.Value1, Value2 = model.Value2, Description1 = model.Description1, Description2 = model.Description2 ,
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
					GroupId = model.GroupId,
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

		public async Task<List<StringGroup>> GetAllStringGroupCurrentPage()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllStringGroupCurrentPage";
				var result = await dbConnection.QueryAsync<StringGroup>(procedure, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public async Task<List<Strings>> GetAllStringListCurrentPage(int groupId)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllStringsCurrentPage";
				var parameters = new { @groupId = groupId, @langid = 0 };
				var result = await dbConnection.QueryAsync<Strings>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public async Task<StringGroup> GetAllStringsByStringGroup(string groupName)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllStringsByStringGroup";
				var parameters = new {@groupName = groupName, @langId = 0 };
				var result = await dbConnection.QueryFirstOrDefaultAsync<StringGroup>(procedure, parameters, commandType: CommandType.StoredProcedure);
				if (result != null)
				{
					string procedure2 = "pGetAllStringsCurrentPage";
					var parameters2 = new { @groupId = result.Id, @langid = 0 };
					var result2 = await dbConnection.QueryAsync<Strings>(procedure2, parameters2, commandType: CommandType.StoredProcedure);
					if (result2.Any())
					{
						result._strings.AddRange(result2);
					}
				}
				return result;
			}
		}
		public async Task<StringGroup> GetAllStringsByStringGroupActive(string groupName)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllStringsByStringGroupActive";
				var parameters = new {@groupName = groupName, @langId = 0 };
				var result = await dbConnection.QueryFirstOrDefaultAsync<StringGroup>(procedure, parameters, commandType: CommandType.StoredProcedure);
				if (result != null)
				{
					string procedure2 = "pGetAllStringsCurrentPageActive";
					var parameters2 = new { @groupId = result.Id, @langid = 0 };
					var result2 = await dbConnection.QueryAsync<Strings>(procedure2, parameters2, commandType: CommandType.StoredProcedure);
					if (result2.Any())
					{
						result._strings.AddRange(result2);
					}
				}
				return result;
			}
		}
	}
}
