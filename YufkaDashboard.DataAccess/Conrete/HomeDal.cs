using Dapper;
using Shared.Context;
using Shared.Models.Home;
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
	public class HomeDal : IHomeDal
	{
		private readonly Context _context;

		public HomeDal(Context context)
		{
			_context = context;
		}

		public async Task<AddBasket> AddBasket(AddBasket model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddBasket";
				var parameters = new { CreatedDate = model.CreatedDate, PaymentTypeId = model.PaymentTypeId, TotalPrice = model.TotalPrice, Status = model.Status };
				var result = await dbConnection.QueryFirstOrDefaultAsync<AddBasket>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}

		public async Task<AddBasketDetail> AddBasketDetail(AddBasketDetail model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddBasketDetail";
				var parameters = new { BasketId = model.BasketId, ProductId = model.ProductId, Amount = model.Amount, Price = model.Price , Status=model.Status};
				var result = await dbConnection.QueryFirstOrDefaultAsync<AddBasketDetail>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}
	}
}
