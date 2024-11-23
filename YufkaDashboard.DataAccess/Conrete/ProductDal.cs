using Dapper;
using Shared.Context;
using Shared.Models.Products;
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
    public class ProductDal : IProductDal
	{
		private readonly Context _context;

		public ProductDal(Context context)
		{
			_context = context;
		}

		public async Task<AddProduct> AddProduct(AddProduct model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddProduct";
				var parameters = new { Name= model.Name, Type=model.Type, UnitPrice = model.UnitPrice,Status=model.Status,CreatedDate=model.CreatedDate,Description=model.Description};
				var result = await dbConnection.QueryFirstOrDefaultAsync<AddProduct>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Products>> GetAllProducts()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllProducts";
				var result = await dbConnection.QueryAsync<Products>(procedure, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public Task<Products> UpdateProduct(Products model)
		{
			throw new NotImplementedException();
		}
	}
}
