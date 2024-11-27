using Dapper;
using Shared.Context;
using Shared.Models.Products;
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

		public async Task<List<Products>> GetAllProducts()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetAllProducts";
				var result = await dbConnection.QueryAsync<Products>(procedure, commandType: CommandType.StoredProcedure);
				return result.ToList();
			}
		}

		public async Task UpdateProduct(Products model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "UpdateProduct";
				var parameters = new
				{
					Id=model.Id,
					Name = model.Name,
					Type = model.Type,
					UnitPrice = model.UnitPrice,
					Description = model.Description,
					CreatedDate = model.CreatedDate,
					Status = model.Status
				};
				await dbConnection.QueryFirstOrDefaultAsync<Products>(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task<Products> GetProductById(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pGetProductById";
				var parameters = new { @id = id };
				var result = await dbConnection.QueryFirstAsync<Products>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}
		public async Task Delete(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string query = @"Delete Products where Id=@id";
				var parameters = new { id };
				await dbConnection.ExecuteAsync(query, parameters, commandType: CommandType.Text);
			}

		}
	}
}
