using Shared.Models.Finance;
using Shared.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YufkaDashboard.DataAccess.Abstract
{
	public interface IFinanceDal
	{
		public Task<SummerGoes> AddSummerGoes(SummerGoes model);
		public Task<SummerGoes> AddMainCaseSummerGoes(SummerGoes model);
		public Task<WriteIncome> AddWriteIncome(WriteIncome model);
		public Task<WriteIncome> AddMainCaseWriteIncome(WriteIncome model);
		public Task<EndDay> AddEndDay(EndDay model);
		public Task<EndDay> AddEndMounthBuy(EndDay model);
		public Task<List<SummerGoes>> GetDailySummerGoes();
		public Task<List<WriteIncome>> GetDailyWriteIncome();
		public Task<List<EndDay>> GetAllEndDays();
		public Task<List<SummerGoes>> GetAllSummerGoes();
		public Task<List<SummerGoes>> GetAllMounthSummerGoes();
		public Task<List<WriteIncome>> GetAllWriteIncome();
		public Task<List<WriteIncome>> GetAllMounthWriteIncome();
		public Task<List<ChartDailyEndDay>> ChartDailyEndDay();
	}
}
