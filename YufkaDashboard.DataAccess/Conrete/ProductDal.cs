using Dapper;
using Shared.Context;
using Shared.Models.Products;
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

		public async Task<AddProduct> AddProduct(AddProduct model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddProduct";
				var parameters = new { Name= model.Name, Type=model.Type, UnitPrice = model.UnitPrice,Status=model.Status};
				var result = await dbConnection.ExecuteScalarAsync<AddProduct>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
				//target.js newtarget kontrol edicez ve devam edicez
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
