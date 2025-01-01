using Dapper;
using Shared.Context;
using Shared.Models.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YufkaDashboard.DataAccess.Abstract;

namespace YufkaDashboard.DataAccess.Conrete
{
	public class FinanceDal:IFinanceDal
	{
		private readonly Context _context;

		public FinanceDal(Context context)
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
				var parameters = new { CashTotal = model.CashTotal, CashDiff = model.CashDiff, CreatedDate = model.CreatedDate, Description = model.Description, IsActive = model.IsActive };
				var result = await dbConnection.QueryFirstOrDefaultAsync<EndDay>(procedure, parameters, commandType: CommandType.StoredProcedure);
				return result;
			}
		}
		public async Task<List<SummerGoes>> GetDailySummerGoes()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "select * from SummerGoes where CAST(CreatedDate as date)=CAST(GETDATE() as date)";
				var result = await dbConnection.QueryAsync<SummerGoes>(procedure, commandType: CommandType.Text);
				return result.ToList();
			}
		}

		public async Task<List<WriteIncome>> GetDailyWriteIncome()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "select * from WriteIncome where CAST(CreatedDate as date)=CAST(GETDATE() as date)";
				var result = await dbConnection.QueryAsync<WriteIncome>(procedure, commandType: CommandType.Text);
				return result.ToList();
			}
		}

		public async Task<List<EndDay>> GetAllEndDays()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "select * from Endday";
				var result = await dbConnection.QueryAsync<EndDay>(procedure, commandType: CommandType.Text);
				return result.ToList();
			}
		}

		public async Task<List<SummerGoes>> GetAllSummerGoes()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "select * from SummerGoes";
				var result = await dbConnection.QueryAsync<SummerGoes>(procedure, commandType: CommandType.Text);
				return result.ToList();
			}
		}

		public async Task<List<WriteIncome>> GetAllWriteIncome()
		{
			using (var dbConnection = _context.CreateConnection())
			{
				string procedure = "select * from WriteIncome";
				var result = await dbConnection.QueryAsync<WriteIncome>(procedure, commandType: CommandType.Text);
				return result.ToList();
			}
		}
	}
}
