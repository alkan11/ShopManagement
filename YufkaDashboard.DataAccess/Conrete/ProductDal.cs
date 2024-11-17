using Dapper;
using Shared.Context;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.DataAccess.Abstract;

namespace YufkaDashboard.DataAccess.Conrete
{
	public class ProductDal : IProductDal
	{
		private readonly Context _context;

		public ProductDal(Context context)
		{
			_context = context;
		}

		public async Task<Products> AddProduct(Products model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddProduct";
				var parameters = new { parameters = model };
				var result = await dbConnection.ExecuteScalarAsync<Products>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
				//business kodunda kaldın
			}
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Products> UpdateProduct(Products model)
		{
			throw new NotImplementedException();
		}
	}
}
