using Dapper;
using Shared.Context;
using Shared.Models.Auth;
using Shared.Models.Documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.DataAccess.Abstract;

namespace YufkaDashboard.DataAccess.Conrete
{
	public class AuthDal : IAuthDal
	{
		private readonly Context _context;

		public AuthDal(Context context)
		{
			_context = context;
		}

		public async Task<List<Users>> GetAllUsers()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllUsers";
				var result = await dbConnection.QueryAsync<Users>(procedure, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}
	}
}
