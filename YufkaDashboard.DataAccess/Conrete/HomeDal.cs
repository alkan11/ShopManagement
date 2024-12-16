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
		public async Task<SummerGoes> AddSummerGoes(SummerGoes model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddSummerGoes";
				var parameters = new { SummerAmount = model.SummerAmount, CreatedDate = model.CreatedDate, Description = model.Description, IsActive = model.IsActive };
				var result = await dbConnection.QueryFirstOrDefaultAsync<SummerGoes>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}
		public async Task<WriteIncome> AddWriteIncome(WriteIncome model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddWriteIncome";
				var parameters = new { WriteIncomeAmount = model.WriteIncomeAmount, CreatedDate = model.CreatedDate, Description = model.Description, IsActive = model.IsActive };
				var result = await dbConnection.QueryFirstOrDefaultAsync<WriteIncome>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}
		public async Task<EndDay> AddEndDay(EndDay model)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "AddEndDay";
				var parameters = new { CashTotal = model.CashTotal, CashDiff=model.CashDiff, CreatedDate = model.CreatedDate, Description = model.Description, IsActive = model.IsActive };
				var result = await dbConnection.QueryFirstOrDefaultAsync<EndDay>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
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

		public async Task DeleteBasketDetail(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pDeleteBasketDetail";
				var parameters = new { @id = id };
				await dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}
		public async Task DeleteBasket(int id)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pDeleteBasket";
				var parameters = new { @id = id };
				await dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}
		public async Task DeleteBasketDetailByBasketId(int basketId)
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "pDeleteBasketDetailByBasketId";
				var parameters = new { @id = basketId };
				await dbConnection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		public async Task<List<RepeaterFormModel>> GetAllBaskets()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				var sql = @"Exec pGetAllBaskets";
				var dictionary = new Dictionary<int, RepeaterFormModel>();
				var list = dbConnection.Query<RepeaterFormModel, Basket, RepeaterFormModel>(
				sql,
				(sd, s) =>
				{
					RepeaterFormModel e;
					if (!dictionary.TryGetValue(sd.Id, out e))
					{
						e = sd;
						dictionary.Add(e.Id, e);
					}
					e.Baskets.Add(s);
					return e;
				},
				splitOn: "BasketDetailId")
				.Distinct()
				.ToList();
				return list;
			}
		}

		public async Task<int> GetDailyBasketCount()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "select Count(Id)Counts from Baskets where CAST(CreatedDate as date)=CAST(GETDATE() as date)";
				var result = await dbConnection.QueryFirstOrDefaultAsync<int>(procedure, commandType: CommandType.Text);
				return result;
			}
		}
	}
}
